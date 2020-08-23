using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Microsoft.AspNetCore.Mvc.ApplicationModels
{
    public class ActionModel
    {
        public ActionModel(IReadOnlyList<object> attributes)
        {
            if (attributes == null)
            {
                throw new ArgumentNullException(nameof(attributes));
            }

            ApiExplorer = new ApiExplorerModel();
            Attributes = new List<object>(attributes);
            Filters = new List<IFilterMetadata>();
            Parameters = new List<ParameterModel>();
        }

        /// <summary>
        /// Copy constructor for <see cref="ActionModel"/>.
        /// </summary>
        /// <param name="other">The <see cref="ActionModel"/> to copy.</param>
        public ActionModel(ActionModel other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            ActionName = other.ActionName;

            // Not making a deep copy of the controller, this action still belongs to the same controller.
            Controller = other.Controller;

            // These are just metadata, safe to create new collections
            Attributes = new List<object>(other.Attributes);
            Filters = new List<IFilterMetadata>(other.Filters);

            // Make a deep copy of other 'model' types.
            ApiExplorer = new ApiExplorerModel(other.ApiExplorer);
            Parameters = new List<ParameterModel>(other.Parameters.Select(p => new ParameterModel(p) { Action = this }));
        }

        /// <summary>
        /// Gets the action name.
        /// </summary>
        public string ActionName { get; set; }

        public ApiExplorerModel ApiExplorer { get; set; }

        public IReadOnlyList<object> Attributes { get; }

        public ControllerModel Controller { get; set; }

        public IList<IFilterMetadata> Filters { get; }

        public IList<ParameterModel> Parameters { get; }
    }
}
