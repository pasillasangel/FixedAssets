using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TierEntities;
using System.Data;
using System.Data.SqlClient;
namespace TierAgreements
{
    public class ChangeAssetsAgreements
    {
        public int AddChangeAsset(ChangeAssets ChangeAE)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("ADD_CHANGE_ASSET", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@idA", ChangeAE.idAssetsfk));
            _command.Parameters.Add(new SqlParameter("@idLoc", ChangeAE.idLocationfkch));
            _command.Parameters.Add(new SqlParameter("@idRes", ChangeAE.idResponsiblefkch));
            _command.Parameters.Add(new SqlParameter("@ped", ChangeAE.pedimento));
            _command.Parameters.Add(new SqlParameter("@cPe", ChangeAE.codePedimento));
            _command.Parameters.Add(new SqlParameter("@vis", ChangeAE.visible));
            _command.Parameters.Add(new SqlParameter("@dateCh", ChangeAE.dateChange));
            _command.Parameters.Add(new SqlParameter("@notes", ChangeAE.notes));
            _command.Parameters.Add(new SqlParameter("@invo", ChangeAE.invoice));
            if (ChangeAE.invoiceDate == null)
                _command.Parameters.Add(new SqlParameter("@invoD", DBNull.Value));
            else
                _command.Parameters.Add(new SqlParameter("@invoD", ChangeAE.invoiceDate));
            _command.Parameters.Add(new SqlParameter("@po", ChangeAE.PO));
            _command.Parameters.Add(new SqlParameter("@ow", ChangeAE.owner));
            _command.Parameters.Add(new SqlParameter("@prov", ChangeAE.provider));
            int result = _command.ExecuteNonQuery();
            _conn.Close();
            return result;
        }


        public List<ChangeAssets> ConsultAllAssetVisible(Asset AssetE)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULT_CHANGE_ASSET", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@id", AssetE.IdAssets));
            IDataReader _reader = _command.ExecuteReader();
            List<ChangeAssets> ListA = new List<ChangeAssets>();
            ChangeAssets _c;
            while (_reader.Read())
            {
                _c = new ChangeAssets();
                _c.idAssetsfk = _reader.GetInt32(0);
                _c.idLocationfkch = _reader.GetInt32(1);
                _c.idResponsiblefkch = _reader.GetInt32(2);
                _c.pedimento = _reader.GetString(3);
                _c.codePedimento = _reader.GetString(4);
                _c.dateChange = _reader.GetDateTime(5);
                _c.notes = _reader.GetString(6);
                _c.invoice = _reader.GetString(7);
                _c.invoiceDate = _reader.GetDateTime(8);
                _c.PO = _reader.GetString(9);
                _c.provider = _reader.GetString(10);
                _c.owner = _reader.GetString(11);
                ListA.Add(_c);
            }
            _conn.Close();
            return ListA;
        }

        public List<JOINChange> ConsultAllAssetChange(Asset AssetE)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULT_CHANGE_ASSET", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@id", AssetE.IdAssets));
            IDataReader _reader = _command.ExecuteReader();
            List<JOINChange> ListA = new List<JOINChange>();
            JOINChange _c;
            while (_reader.Read())
            {
                _c = new JOINChange();
                _c.idAsset = _reader.GetInt32(0);
                _c.Location = _reader.GetString(1);
                _c.Responsible = _reader.GetString(2);
                _c.Pedimento = _reader.GetString(3);
                _c.codePedimento = _reader.GetString(4);
                _c.dateChange = _reader.GetDateTime(5);
                _c.notes = _reader.GetString(6);
                _c.invoice = _reader.GetString(7);

                if (_reader.IsDBNull(8))
                    _c.invoiceDate = null;
                else
                    _c.invoiceDate = _reader.GetDateTime(8);

                _c.PO = _reader.GetString(9);
                _c.provider = _reader.GetString(10);
                _c.owner = _reader.GetString(11);
                ListA.Add(_c);
            }
            _conn.Close();
            return ListA;
        }

    }
}
