using AECSCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAL
{
    public class UserContext : DbContext
    {
        #region Models

        private DbSet<Department> _departments;
        public DbSet<Department> Departments
        {
            get
            {
                if (_departments == null)
                {
                    _departments = this.Set<Department>();
                }
                return _departments;
            }
            set
            {
                _departments = value;
            }
        }

        private DbSet<Person> _persons;
        public DbSet<Person> Persons
        {
            get
            {
                if (_persons == null)
                {
                    _persons = this.Set<Person>();
                }
                return _persons;
            }
            set
            {
                _persons = value;
            }
        }

        private DbSet<Tool> _allTools;
        public DbSet<Tool> AllTools
        {
            get
            {
                if (_allTools == null)
                {
                    _allTools = this.Set<Tool>();
                }
                return _allTools;
            }
        }
        private DbSet<Profession> _professions;
        public DbSet<Profession> Professions
        {
            get
            {
                if (_professions == null)
                {
                    _professions = this.Set<Profession>();
                }
                return _professions;
            }
            set
            {
                _professions = value;
            }
        }
        private DbSet<Machine> _machines;
        public DbSet<Machine> Machines
        {
            get
            {
                if (_machines == null)
                {
                    _machines = this.Set<Machine>();
                }
                return _machines;
            }
            set
            {
                _machines = value;
            }
        }     

        #endregion Models
   
        public UserContext()
            : base("EntityConnectionString")
        {
            TestDB();
        }

        public static UserContext GetInstance()
        {
             
            return new UserContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Worker>().ToTable("Workers");


             modelBuilder.Entity<Item>().ToTable("Items");
                modelBuilder.Entity<Tool>().Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("Tools");
                });
        }
        
        [TestMethod]
        private void TestDB()
        {
            try
            {
                Departments.Where(x => 1 == 0).Load();
            }
            catch (NotSupportedException)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<UserContext>());  
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}
