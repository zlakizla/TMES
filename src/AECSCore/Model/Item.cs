using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AECSCore
{
    public class Item
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public Int32 Id { get; set; }

        /// <summary>
        /// Шифр экземпляра
        /// </summary>
        public String Code {get; set;}

        private Int32? _uniqueId;
        /// <summary>
        /// Уникальный идентификатор экземпляра
        /// </summary>
        public Int32? UniqueId 
        { 
            get
            {
                return _uniqueId;
            }
            set
            {
                if(Amount != 1)
                {
                    throw new InvalidOperationException(@"Невозможно задать уникальный
                    номер предмету, для которого задано количество");
                }
            }
        }

        private Double _amount;
        public Double Amount 
        { 
            get
            {
                return _amount;
            }
            set
            {
                if(UniqueId.HasValue)
                {
                    throw new InvalidOperationException(@"Невозможно задать количество
                    для предмета с уникальным номером");
                }
                _amount = value;            
            }
        }

        public Int32 HolderId { get; set; }

        private Person _holder;
        [ForeignKey("HolderId")]
        public Person Holder
        {
            get
            {
                return _holder;
            }
            set
            {
                _holder = value;
            }
        }

    }
}
