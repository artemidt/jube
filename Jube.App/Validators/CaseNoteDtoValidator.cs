/* Copyright (C) 2022-present Jube Holdings Limited.
 *
 * This file is part of Jube™ software.
 *
 * Jube™ is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License 
 * as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * Jube™ is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty  
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details.

 * You should have received a copy of the GNU Affero General Public License along with Jube™. If not, 
 * see <https://www.gnu.org/licenses/>.
 */

using FluentValidation;
using Jube.App.Dto;

namespace Jube.App.Validators
{
    public class CaseNoteDtoValidator : AbstractValidator<CaseNoteDto>
    {
        public CaseNoteDtoValidator()
        {
            RuleFor(p => p.Note).NotEmpty();
            RuleFor(p => p.ActionId).GreaterThan(0);
            RuleFor(p => p.PriorityId).GreaterThan(0);
            RuleFor(p => p.CaseKey).NotEmpty();
            RuleFor(p => p.CaseKeyValue).NotEmpty();
            RuleFor(p => p.CaseId).GreaterThan(0);
            RuleFor(p => p.Payload).NotEmpty();
        }
    }
}