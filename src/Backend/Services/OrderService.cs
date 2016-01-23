using System;
using System.Collections.Generic;
using Entities;

namespace Backend
{
    public class OrderService
    {
        public IList<GanttData> GetDetails(Order Order)
        {
            var Result = new List<GanttData>();
            var RootWorks = new List<GanttData>();

            // Корень заказа 
            var Root = new GanttData()
            {
                id = 1,
                text = Order.Code,
                order = 10,
                start_date = "11-04-2013", // Дата открытия заказа, от нее будет считаться все остальное
                duration = 10,
                open = true,
                progress = 0
            };
            Result.Add(Root);

            ExplodeOrder(Order);

            RootWorks = GetRootWorks();
            Result.AddRange(RootWorks);

            return Result;
        }

        // Вызвать хранимку, которая разузлует заказ и поместит результаты в таблицу tempPOSPRIMB
        public void ExplodeOrder(Order Order)
        {
            var dbManager = DatabaseManager.GetInstance();
            String Request = @"EXEC [1gb_x_t_mes].[dbo].[RAZUZLOVZAKAZ] 'netGraf',@OrderId";
            var RequestArgs = new Dictionary<String,Object>();
            RequestArgs.Add("OrderId",Order.Code);
            //  dbManager.SendCommand(Request,RequestArgs);
        }

        // Получить из базы корневые работы в виде: "Цех:Трудоемкость"
        public List<GanttData> GetRootWorks()
        {
            var Result = new List<GanttData>();
            var dbManager = DatabaseManager.GetInstance();
            String Request = @"SELECT 
                                        C, 
                                        Duration
                               FROM [1gb_x_t_mes].[dbo].[RootWorks] where id='netGraf' ";
            var Rows = dbManager.SendRequest(Request);
            var Index = 2;
            foreach(var Row in Rows)
            {
                var GanttData = new GanttData()
                {
                    id = Index,
                    text = Row["C"].ToString(),
                    start_date = "11-04-2013",
                    order = 10,
                    duration = Convert.ToDouble(Row["Duration"]),
                    parent = 1,
                    progress = 0.5
                };
                Result.Add(GanttData);
                Index++;
            }
            return Result;
        }

        // Получить заказ по номеру
        public Order GetOrderById(Int32 OrderId)
        {
            var Result = new Order();

            var dbManager = DatabaseManager.GetInstance();
            String Request = @"SELECT zakaz, NaimZak
                            FROM [Zakaz]
                            WHERE zakaz = @Order";
            var RequestArgs = new Dictionary<String,Object>();
            RequestArgs.Add("Order",OrderId);
            var Rows = dbManager.SendRequest(Request, RequestArgs);

            if(Rows.Count > 0)
            {
                Result.Code = Rows[0]["zakaz"] as String;
                Result.Name = Rows[0]["NaimZak"] as String;
            }
            return Result;
        }


        public List<Exploder> GetExploderOrder(Int32 order, int parent)
        {
            var result = new List<Exploder>();
            var dbManager = DatabaseManager.GetInstance();
            String Request = @"SELECT id_record, TIP, IND1, PICH, Depth, KSZ 
                            FROM[1gb_x_t_mes].dbo.tempPOSPRIMB WHERE Parent = @Parent and Z=@Z  and id like 'net%'";
            var RequestArgs = new Dictionary<String, Object>();
            RequestArgs.Add("Parent", parent);
            RequestArgs.Add("Z", order);
            var Rows = dbManager.SendRequest(Request, RequestArgs);

            foreach (var Row in Rows)
            {
                var Exploder = new Exploder
                {
                    id_record = Row["id_record"].ToString(),
                    Type = Row["TIP"].ToString(),
                    Ind = Row["IND1"].ToString(),
                    Denotation = Row["PICH"].ToString(),
                    Depth = Row["Depth"].ToString(),
                    Amount = Row["KSZ"].ToString()
                };
                result.Add(Exploder);
            }

            return result;
        }


        public List<WorkDetail> GetWorkDetails(int idRecord)
        {
            var result = new List<WorkDetail>();

            var dbManager = new DatabaseManager();
            var Request = @"SELECT IND1, PICH, F, C, NV, NAZVO 
                           FROM [1gb_x_t_mes].dbo.BlocksByOperation WHERE id = 'netGraf' AND id_record=@idRecord ";
            var RequestArgs= new Dictionary<String, Object>();
            RequestArgs.Add("idRecord", idRecord);
            var Rows = dbManager.SendRequest(Request, RequestArgs);

            foreach (var Row in Rows)
            {
                var WorkDetail = new WorkDetail
                {
                    Ind = Row["IND1"].ToString(),
                    Denotation = Row["PICH"].ToString(),
                    Chain = Row["F"].ToString(),
                    Department = Row["C"].ToString(),
                    Duration = Row["NV"].ToString(),
                    Operation = Row["NAZVO"].ToString()
                };
                result.Add(WorkDetail);
            }
            return result;

        }
    }
}