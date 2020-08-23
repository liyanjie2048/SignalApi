// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Microsoft.AspNetCore.Mvc.ApplicationModels
{
    public class ControllerModel :  IApiExplorerModel
    {
        public ControllerModel(
            TypeInfo controllerType,
            IReadOnlyList<object> attributes)
        {
            if (controllerType == null)
            {
                throw new ArgumentNullException(nameof(controllerType));
            }

            if (attributes == null)
            {
                throw new ArgumentNullException(nameof(attributes));
            }

            ControllerType = controllerType;

            Actions = new List<ActionModel>();
            ApiExplorer = new ApiExplorerModel();
            Attributes = new List<object>(attributes);
            Filters = new List<IFilterMetadata>();
        }

        public ControllerModel(ControllerModel other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            ControllerName = other.ControllerName;
            ControllerType = other.ControllerType;

            // These are just metadata, safe to create new collections
            Attributes = new List<object>(other.Attributes);
            Filters = new List<IFilterMetadata>(other.Filters);

            // Make a deep copy of other 'model' types.
            Actions = new List<ActionModel>(other.Actions.Select(a => new ActionModel(a) { Controller = this }));
            ApiExplorer = new ApiExplorerModel(other.ApiExplorer);
        }

        /// <summary>
        /// The actions on this controller.
        /// </summary>
        public IList<ActionModel> Actions { get; }

        /// <summary>
        /// Gets or sets the <see cref="ApiExplorerModel"/> for this controller.
        /// </summary>
        /// <remarks>
        /// <see cref="ControllerModel.ApiExplorer"/> allows configuration of settings for ApiExplorer
        /// which apply to all actions in the controller unless overridden by <see cref="ActionModel.ApiExplorer"/>.
        ///
        /// Settings applied by <see cref="ControllerModel.ApiExplorer"/> override settings from
        /// <see cref="ApplicationModel.ApiExplorer"/>.
        /// </remarks>
        public ApiExplorerModel ApiExplorer { get; set; }

        public IReadOnlyList<object> Attributes { get; }

        /// <summary>
        /// The name of this controller.
        /// </summary>
        public string ControllerName { get; set; }

        public TypeInfo ControllerType { get; }

        public IList<IFilterMetadata> Filters { get; }
    }
}
