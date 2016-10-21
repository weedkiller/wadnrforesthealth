﻿using FluentValidation;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class BasicsViewModelValidator : AbstractValidator<BasicsViewModel>
    {
        public BasicsViewModelValidator()
        {
            RuleFor(x => x.ProjectDescription).NotEmpty().WithName(Models.FieldDefinition.ProjectDescription.FieldDefinitionDisplayName);
            RuleFor(x => x.ProjectStageID).NotEmpty().WithName(Models.FieldDefinition.Stage.FieldDefinitionDisplayName);
        }
    }
}