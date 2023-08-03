using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;

namespace Fast.Template.Start
{
    public class StartMvcPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        private readonly ApplicationPartManager _partManager;
        //private readonly ApplicationModel _applicationModel;

        public StartMvcPermissionDefinitionProvider(ApplicationPartManager partManager)
        {
            _partManager = partManager;
            //, ApplicationModel applicationModel
            //_applicationModel = applicationModel;
        }

        public override void Define(IPermissionDefinitionContext context)
        {
            var controllerFeature = new ControllerFeature();
            _partManager.PopulateFeature(controllerFeature);
            var controllerTypes = controllerFeature.Controllers.Where(c=>c.Name.EndsWith("AppService")).ToList();

            //var controllers = _applicationModel.Controllers.ToList();
        }
    }
}
