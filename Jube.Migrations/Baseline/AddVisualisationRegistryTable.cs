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
    [Migration(20220429125027)]
    public class AddVisualisationRegistryTable : Migration
    {
        public override void Up()
        {
            Create.Table("VisualisationRegistry")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("CreatedUser").AsString().Nullable()
                .WithColumn("Active").AsByte().Nullable()
                .WithColumn("Locked").AsByte().Nullable()
                .WithColumn("CreatedDate").AsDateTime2().Nullable()
                .WithColumn("ShowInDirectory").AsByte().Nullable()
                .WithColumn("Deleted").AsByte().Nullable()
                .WithColumn("DeletedDate").AsDateTime2().Nullable()
                .WithColumn("DeletedUser").AsString().Nullable()
                .WithColumn("UpdatedDate").AsDateTime2().Nullable()
                .WithColumn("UpdatedUser").AsString().Nullable()
                .WithColumn("TenantRegistryId").AsInt32().Nullable()
                .WithColumn("Columns").AsInt32().Nullable()
                .WithColumn("ColumnWidth").AsInt32().Nullable()
                .WithColumn("RowHeight").AsInt32().Nullable()
                .WithColumn("Version").AsInt32().Nullable();
            
            Insert.IntoTable("VisualisationRegistry").Row(new
            {
                Name = "ExampleVisualisation",
                CreatedUser = "Administrator",
                CreatedDate = DateTime.Now,
                Active = 1,
                ShowInDirectory = 1,
                TenantRegistryId = 1,
                Columns = 6,
                ColumnWidth = 300,
                RowHeight = 300,
                Version = 1
            });
            
            Insert.IntoTable("VisualisationRegistry").Row(new
            {
                Name = "ExampleEmbeddedVisualisation",
                CreatedUser = "Administrator",
                CreatedDate = DateTime.Now,
                Active = 1,
                ShowInDirectory = 0,
                TenantRegistryId = 1,
                Columns = 6,
                ColumnWidth = 300,
                RowHeight = 300,
                Version = 1
            });
        }

        public override void Down()
        {
            Delete.Table("VisualisationRegistry");
        }
    }
}