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

using FluentMigrator;

namespace Jube.Migrations.Baseline
{
    [Migration(20220429124955)]
    public class AddExhaustiveSearchInstancePromotedTrialInstanceRocTableIndex : Migration
    {
        public override void Up()
        {
            Create.Table("ExhaustiveSearchInstancePromotedTrialInstanceRoc")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("TruePositive").AsInt32().Nullable()
                .WithColumn("TrueNegative").AsInt32().Nullable()
                .WithColumn("FalsePositive").AsInt32().Nullable()
                .WithColumn("FalseNegative").AsInt32().Nullable()
                .WithColumn("Score").AsDouble().Nullable()
                .WithColumn("Threshold").AsDouble().Nullable()
                .WithColumn("ExhaustiveSearchInstanceTrialInstanceId").AsInt32().Nullable();

            Create.Index().OnTable("ExhaustiveSearchInstancePromotedTrialInstanceRoc")
                .OnColumn("ExhaustiveSearchInstanceTrialInstanceId").Ascending();
        }

        public override void Down()
        {
            Delete.Table("ExhaustiveSearchInstancePromotedTrialInstanceRoc");
        }
    }
}