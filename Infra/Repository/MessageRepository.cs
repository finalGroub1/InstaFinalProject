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
    public class MessageRepository : ImessageRepository
    {
        private readonly IDBContext _IDBContext;
        

        public MessageRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
            
        }

        public bool deleteMessage(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Mid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Message_package.deleteMessage", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Message> getallMessage(int sender, int reciver)
        {
            
            IEnumerable<Message> result = _IDBContext.Connection.Query<Message>("Message_package.getallMessage", commandType: CommandType.StoredProcedure)
                .Where(x=> x.user_id_send == sender && x.user_id_res == reciver || x.user_id_send == reciver && x.user_id_res == sender).OrderBy(x=> x.id);
            
            return result.ToList();
        }
        public User getbyidUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<User>("User_F_package.getbyidUser", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public Message getbyidMessage(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Mid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Message>("Message_package.getbyidMessage", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertMessage(Message message)
        {
            var p = new DynamicParameters();
            p.Add("@Mtextme", message.textme, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Mtimeme", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Tuser_id_send", message.user_id_send, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Tuser_id_resp", message.user_id_res, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Message_package.insertMessage", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateMessage(Message message)
        {
            var p = new DynamicParameters();
            p.Add("@Mid", message.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Mtextme", message.textme, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Mtimeme", message.timeme, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Tuser_id_send", message.user_id_send, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Tuser_id_resp", message.user_id_res, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Message_package.updateMessage", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
