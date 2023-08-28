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
    [Migration(20220429124903)]
    public class AddCaseEventTableIndex : Migration
    {
        public override void Up()
        {
            Create.Table("CaseEvent")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("CaseEventTypeId").AsInt32().Nullable()
                .WithColumn("Before").AsString().Nullable()
                .WithColumn("CreatedUser").AsString().Nullable()
                .WithColumn("CreatedDate").AsDateTime2().Nullable()
                .WithColumn("CaseKey").AsString().Nullable()
                .WithColumn("After").AsString().Nullable()
                .WithColumn("CaseKeyValue").AsString().Nullable()
                .WithColumn("CaseId").AsInt32().Nullable();

            Create.Index().OnTable("CaseEvent")
                .OnColumn("CaseKey").Ascending()
                .OnColumn("CaseKeyValue").Ascending();

        }

        public override void Down()
        {
            Delete.Table("CaseEvent");
        }
    }
}