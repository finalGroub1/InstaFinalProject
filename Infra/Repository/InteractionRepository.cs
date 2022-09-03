using Core.Common;
using Core.Data;
using Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infra.Repository
{
    public class InteractionRepository : IInteractionRepository
    {
        private readonly IDBContext _IDBContext;

        public InteractionRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteInterAction(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofInterAction", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("InterAction_package.deleteInterAction", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Interaction> getallInterAction()
        {
            IEnumerable<Interaction> result = _IDBContext.Connection.Query<Interaction>("InterAction_package.getallInterAction", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Interaction getbyidInterAction(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofInterAction", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Interaction>("InterAction_package.getbyidInterAction", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertInterAction(Interaction Interaction)
        {
            var p = new DynamicParameters();
            p.Add("@iType", Interaction.intertype, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uid", Interaction.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pid", Interaction.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Sid", Interaction.story_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Idatelike", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("InterAction_package.insertInterAction", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateInterAction(Interaction Interaction)
        {
            var p = new DynamicParameters();
            p.Add("@idofInterAction", Interaction.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@iType", Interaction.intertype, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uid", Interaction.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pid", Interaction.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Sid", Interaction.story_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Idatelike", Interaction.datelike, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("InterAction_package.updateInterAction", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
