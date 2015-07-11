using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMES.ViewModel
{
    class EnterpriseViewModel : ModuleViewModel
    {
        public EnterpriseViewModel()
        {
            base.Name = "ПРЕДПРИЯТИЕ";
            base.Icon = "Enterprise.png";
            base.OpenedModules.Add(new DepartmentManagerViewModel());
            base.OpenedModules.Add(new MachineManagerViewModel());
            base.OpenedModules.Add(new PersonManagerViewModel());
            base.OpenedModules.Add(new ToolsViewModel());
            OpenedModules.Add(new ProfessionManagerViewModel());
        }
    }
}
