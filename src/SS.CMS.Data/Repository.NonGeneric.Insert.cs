﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SS.CMS.Data.Utils;

namespace SS.CMS.Data
{
    public partial class Repository
    {
        public virtual int Insert<T>(T dataInfo) where T : Entity
        {
            return RepositoryUtils.InsertObject(Db, TableName, TableColumns, dataInfo);
        }

        public virtual async Task<int> InsertAsync<T>(T dataInfo) where T : Entity
        {
            return await RepositoryUtils.InsertObjectAsync(Db, TableName, TableColumns, dataInfo);
        }

        public virtual async Task BulkInsertAsync<T>(IEnumerable<T> items) where T : Entity
        {
            await RepositoryUtils.BulkInsertAsync<T>(Db, TableName, TableColumns, items);
        }

        public virtual async Task BulkInsertAsync(IEnumerable<JObject> items)
        {
            await RepositoryUtils.BulkInsertAsync(Db, TableName, TableColumns, items);
        }

        public virtual async Task BulkInsertAsync(IEnumerable<IDictionary<string, object>> items)
        {
            await RepositoryUtils.BulkInsertAsync(Db, TableName, TableColumns, items);
        }
    }
}
