using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Authorization.Permissions;

namespace Fast.Template.Start
{
    public class StartMvcPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        private readonly ApplicationPartManager _partManager;
        private readonly IApplicationFeatureProvider<ControllerFeature> _controllerFeatureProvider;
        private readonly MvcOptions _mvcOptions;

        private readonly AbpAspNetCoreMvcOptions _abpAspNetCoreMvcOptions;
        //private readonly ApplicationModel _applicationModel;

        public StartMvcPermissionDefinitionProvider(ApplicationPartManager partManager, IOptions<AbpAspNetCoreMvcOptions> abpAspNetCoreMvcOptions,IOptions<MvcOptions> mvcOptions)
        {
            _partManager = partManager;
            _mvcOptions = mvcOptions.Value;
            _abpAspNetCoreMvcOptions = abpAspNetCoreMvcOptions.Value;
            //, ApplicationModel applicationModel
            //_applicationModel = applicationModel;
        }

        public override void Define(IPermissionDefinitionContext context)
        {
            var controllerFeature = new ControllerFeature();
            _partManager.PopulateFeature(controllerFeature);
            var controllerTypes = controllerFeature.Controllers
                                                //.Where(c => c.Name.EndsWith("AppService"))
                                                .ToList();

            foreach (var controllerTypeInfo in controllerTypes)
            {
                var controllerType = controllerTypeInfo.AsType();
                if (controllerType.GetCustomAttribute<AllowAnonymousAttribute>() != null) continue;

                var attrs1 = controllerType.GetCustomAttributes();

                var methodInfos = controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(method => !method.IsSpecialName 
                                                         && method.Name != nameof(GetType)
                                                         && method.Name != nameof(ToString)
                                                         && method.Name != nameof(GetHashCode)).ToList();

                foreach (var methodInfo in methodInfos)
                {
                    var attrs = methodInfo;
                }
            }

            #region mvcOptions

            //foreach (var setting in _abpAspNetCoreMvcOptions.ConventionalControllers.ConventionalControllerSettings)
            //{
            //    var group = setting.RootPath;
            //    //var attr = assembly.CustomAttributes.ToList();

            //    var services = setting.GetControllerTypes();

            //    foreach (var service in services)
            //    {
            //        var actions = service.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            //                                    .Where(method => !method.IsSpecialName ).ToList();
            //    }
            //}

            //var cons = _mvcOptions.Conventions;

            #endregion

            //foreach (var controller in controllerModels)
            //{
            //    var actions = controller.Actions.ToList();
            //}

            //var controllers = _applicationModel.Controllers.ToList();
        }
    }
}
