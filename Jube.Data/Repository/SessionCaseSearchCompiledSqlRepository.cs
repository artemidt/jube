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
using System.Linq;
using Jube.Data.Context;
using Jube.Data.Poco;
using LinqToDB;

namespace Jube.Data.Repository
{
    public class SessionCaseSearchCompiledSqlRepository
    {
        private readonly DbContext _dbContext;
        private readonly string _userName;

        public SessionCaseSearchCompiledSqlRepository(DbContext dbContext, string userName)
        {
            _dbContext = dbContext;
            _userName = userName;
        }

        public SessionCaseSearchCompiledSql GetByGuid(Guid guid)
        {
            return _dbContext.SessionCaseSearchCompiledSql
                .FirstOrDefault(w => w.Guid == guid);
        }

        public SessionCaseSearchCompiledSql GetByLast()
        {
            return _dbContext.SessionCaseSearchCompiledSql
                .Where(w => w.CreatedUser == _userName)
                .OrderByDescending(o => o.Id)
                .FirstOrDefault();
        }

        public SessionCaseSearchCompiledSql Insert(SessionCaseSearchCompiledSql model)
        {
            model.CreatedUser = _userName;
            model.CreatedDate = DateTime.Now;
            model.Guid = Guid.NewGuid();

            model.Id = _dbContext.InsertWithInt32Identity(model);

            return model;
        }
    }
}