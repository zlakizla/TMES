using AECSCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Utils;

namespace NetGraph.ViewModels
{
    public class WorkDetailViewModel
    {
        private IEnumerable<Work> _content;
        public IEnumerable<Work> Content
        {
            get
            {
                if (_content == null)
                {
                    _content = new List<Work>();
                }
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        public Element Element;
        public WorkDetailViewModel(Element Element = null)
        {
            if(Element != null)
            {
                this.Content = GetWorkByElement(Element);
            }
        }

        public IEnumerable<Work> GetWorkByElement(Element Element)
        {
            var Result = new List<Work>();
            var ConnString = WebConfigurationManager.ConnectionStrings["DebugConn"].ConnectionString;

            using(SqlConnection Conn = new SqlConnection(ConnString))
            {
                Conn.Open();
                using(var Cmd = new SqlCommand("",Conn))
                {
                    Cmd.CommandText = @"SELECT [TIP]
                                      ,[IND]
                                      ,[PICH]
                                      ,[C]
                                      ,[F]
                                      ,[NSI].[dbo].[TEXNORM].[L]
                                      ,[NV]
                                      ,[obozn]
	                                  ,NSI.dbo.NAPROF.NAZVO
                                  FROM [NSI].[dbo].[TEXNORM]
   INNER JOIN NSI.dbo.NAPROF ON NSI.dbo.NAPROF.L = [NSI].[dbo].[TEXNORM].L
   WHERE IND = @IND AND PICH = @PICH
   ORDER BY F Asc";
                    Cmd.Parameters.AddWithValue("IND", Element.Index);
                    Cmd.Parameters.AddWithValue("PICH", Element.Denotation);
                    using(var dr = Cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            var Work = new Work();
                            Work.Duration = (Double)dr["NV"];
                            Work.Name = (String)dr["NAZVO"];
                            Work.ChainNumber = Convert.ToInt32(dr["F"]);
                            Work.Department = new Department()
                            {
                                ShortName = dr["C"].ToString()
                            };
                            Work.Element = Element;
                            Result.Add(Work);
                        }
                    }
                }
            }
            return Result;
        }
    }
}