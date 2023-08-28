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

using System;
using FluentMigrator;

namespace Jube.Migrations.Baseline
{
    [Migration(20220430125452)]
    public class AddUserInTenantTableIndex : Migration
    {
        public override void Up()
        {
            Create.Table("UserInTenant")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("User").AsString().Nullable()
                .WithColumn("TenantRegistryId").AsInt32().Nullable()
                .WithColumn("SwitchedUser").AsString().Nullable()
                .WithColumn("SwitchedDate").AsDateTime().Nullable();

            Create.Index().OnTable("UserInTenant").OnColumn("User").Ascending();
            
            Insert.IntoTable("UserInTenant").Row(new
            {
                User = "Administrator",
                TenantRegistryId = 1,
                SwitchedDate = DateTime.Now,
                SwitchedUser = "Administrator"
            });
        }

        public override void Down()
        {
            Delete.Table("UserInTenant");
        }
    }
}