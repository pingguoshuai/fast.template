using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace Fast.Template.Start
{
    public class PermissionConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            var controllerModels = application.Controllers;

            foreach (var controllerModel in controllerModels)
            {
                var actions = controllerModel.Actions;
                foreach (var action in actions)
                {
                    var selectors = action.Selectors;
                    foreach (var selectorModel in selectors)
                    {
                        var routeModel = selectorModel.AttributeRouteModel;
                    }
                }
            }
        }
    }
}
