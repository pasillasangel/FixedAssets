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
    public class AssetsAgreements
    {
        public int AddAsset(Asset AssetE)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("ADD_ASSET", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@pn", AssetE.partNumber));
            _command.Parameters.Add(new SqlParameter("@descr", AssetE.descrip));
            _command.Parameters.Add(new SqlParameter("@br", AssetE.brand));
            _command.Parameters.Add(new SqlParameter("@mo", AssetE.model));
            _command.Parameters.Add(new SqlParameter("@se", AssetE.serial));
            _command.Parameters.Add(new SqlParameter("@in", AssetE.invoice));

            if (AssetE.invoiceDate == null)
                _command.Parameters.Add(new SqlParameter("@inD", DBNull.Value));
            else
                _command.Parameters.Add(new SqlParameter("@inD", AssetE.invoiceDate));
            
            _command.Parameters.Add(new SqlParameter("@pe", AssetE.pedimento));
            _command.Parameters.Add(new SqlParameter("@cPe", AssetE.codePedimento));
            _command.Parameters.Add(new SqlParameter("@pro", AssetE.provider));
            _command.Parameters.Add(new SqlParameter("@cost", AssetE.cost));
            _command.Parameters.Add(new SqlParameter("@pic", AssetE.picture));
            _command.Parameters.Add(new SqlParameter("@dCre", AssetE.dateCreate));
            _command.Parameters.Add(new SqlParameter("@idLocfk", AssetE.idLocationfk));
            _command.Parameters.Add(new SqlParameter("@idRes", AssetE.idResponsiblefk));
            _command.Parameters.Add(new SqlParameter("@notes", AssetE.notes));
            _command.Parameters.Add(new SqlParameter("@po", AssetE.PO));
            _command.Parameters.Add(new SqlParameter("@ow", AssetE.owner));
            _command.Parameters.Add(new SqlParameter("@cmx", AssetE.costmx));


            int result = _command.ExecuteNonQuery();
            _conn.Close();
            return result;
        }

        public int LastId()
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("LAST_ID", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _command.ExecuteReader();
            int last = 0;
            while (_reader.Read())
            {
                last = _reader.GetInt32(0);
            }
            _conn.Close();
            return last;
        }

        public int UpdatePicture(Asset AssetE)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("UPDATE_PICTURE", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@id", AssetE.IdAssets));
            _command.Parameters.Add(new SqlParameter("@pic", AssetE.picture));
            int result = _command.ExecuteNonQuery();
            _conn.Close();
            return result;
        }

        public int UpdateAsset(Asset AssetE)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("UPDATE_ASSET", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@id", AssetE.IdAssets));
            _command.Parameters.Add(new SqlParameter("@pe", AssetE.pedimento));
            _command.Parameters.Add(new SqlParameter("@cPe", AssetE.codePedimento));
            _command.Parameters.Add(new SqlParameter("@idLocfk", AssetE.idLocationfk));
            _command.Parameters.Add(new SqlParameter("@idRes", AssetE.idResponsiblefk));
            _command.Parameters.Add(new SqlParameter("@notes", AssetE.notes));
            _command.Parameters.Add(new SqlParameter("@invo", AssetE.invoice));
            if (AssetE.invoiceDate != null)
                _command.Parameters.Add(new SqlParameter("@invoD", AssetE.invoiceDate));
            else
                _command.Parameters.Add(new SqlParameter("@invoD", DBNull.Value));
            _command.Parameters.Add(new SqlParameter("@po", AssetE.PO));
            _command.Parameters.Add(new SqlParameter("@ow", AssetE.owner));
            _command.Parameters.Add(new SqlParameter("@prov", AssetE.provider));
            int result = _command.ExecuteNonQuery();
            _conn.Close();
            return result;
        }

        public Asset SearchAsset(Asset AssetE)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("SEARCH_ASSET", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@id", AssetE.IdAssets));
            IDataReader _reader = _command.ExecuteReader();
            Asset _a = new Asset();
            if (_reader.Read())
            {
                _a.IdAssets = _reader.GetInt32(0);
                _a.partNumber = _reader.GetString(1);
                _a.descrip = _reader.GetString(2);
                _a.brand = _reader.GetString(3);
                _a.model = _reader.GetString(4);
                _a.serial = _reader.GetString(5);
                _a.invoice = _reader.GetString(6);
                
                if (_reader.IsDBNull(7))
                    _a.invoiceDate = null;
                else
                    _a.invoiceDate = _reader.GetDateTime(7);

                _a.pedimento = _reader.GetString(8);
                _a.codePedimento = _reader.GetString(9);
                _a.provider = _reader.GetString(10);
                _a.cost = _reader.GetDecimal(11);
                _a.dateCreate = _reader.GetDateTime(12);

                if (_reader.IsDBNull(13))
                    _a.dateLow = null;
                else
                    _a.dateLow = _reader.GetDateTime(13);

                if (_reader.IsDBNull(14))
                    _a.picture = "";
                else
                    _a.picture = _reader.GetString(14);
                _a.visible = _reader.GetBoolean(15);
                _a.idLocationfk = _reader.GetInt32(16);
                _a.idResponsiblefk = _reader.GetInt32(17);
                _a.notes = _reader.GetString(18);
                _a.PO = _reader.GetString(19);
                _a.owner = _reader.GetString(20);
                _a.costmx = _reader.GetDecimal(21);
            }
            _conn.Close();
            return _a;
        }


        public int SearchId(Asset AssetE)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("SEARCH_ID", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@id", AssetE.IdAssets));
            int result = _command.ExecuteNonQuery();
            _conn.Close();
            return result;
        }

        public int RemoveAsset(Asset AssetE)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("REMOVE_ASSET", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@id", AssetE.IdAssets));
            int result = _command.ExecuteNonQuery();
            _conn.Close();
            return result;
        }

        public List<string> FillResponsible()
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("FILL_RESPONSIBLE", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _command.ExecuteReader();
            List<string> ListR = new List<string>();
            while (_reader.Read())
            {
                ListR.Add(_reader.GetString(0));
            }
            _conn.Close();
            return ListR;
        }

        public List<string> FillLocation()
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("FILL_LOCATION", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _command.ExecuteReader();
            List<string> ListR = new List<string>();
            while (_reader.Read())
            {
                ListR.Add(_reader.GetString(0));
            }
            _conn.Close();
            return ListR;
        }

        public List<JOINConsultAsset> ConsultAllAssetVisible()
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULT_ALL_ASSET_VISIBLE", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _command.ExecuteReader();
            List<JOINConsultAsset> ListA = new List<JOINConsultAsset>();
            JOINConsultAsset _a;
            while (_reader.Read())
            {
                _a = new JOINConsultAsset();
                _a.id = _reader.GetInt32(0);
                _a.description = _reader.GetString(1);
                _a.location = _reader.GetString(2);
                _a.responsible = _reader.GetString(3);
                _a.cost = _reader.GetDecimal(4);
                _a.CostMx = _reader.GetDecimal(5);
                _a.brand = _reader.GetString(6);
                _a.model = _reader.GetString(7);
                _a.serial = _reader.GetString(8);
                _a.invoice = _reader.GetString(9);
                if (_reader.IsDBNull(10))
                    _a.invoiceDate = null;
                else
                    _a.invoiceDate = _reader.GetDateTime(10);
                _a.pedimento = _reader.GetString(11);
                _a.codePedimento = _reader.GetString(12);
                _a.provider = _reader.GetString(13);
                _a.dateCreate = _reader.GetDateTime(14);
                _a.PO = _reader.GetString(15);
                _a.Owner = _reader.GetString(16);
                _a.notes = _reader.GetString(17);

                ListA.Add(_a);

            }
            _conn.Close();
            return ListA;
        }

        public List<JOINConsultAsset> ConsultAssetNormal(string descrip)
        {   //ACOMODAR DATOS
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULT_ASSETS_NORMAL", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@search", descrip);
            IDataReader _reader = _command.ExecuteReader();
            List<JOINConsultAsset> ListA = new List<JOINConsultAsset>();
            JOINConsultAsset _a;
            while (_reader.Read())
            {
                _a = new JOINConsultAsset();
                _a.id = _reader.GetInt32(0);
                _a.description = _reader.GetString(1);
                _a.location = _reader.GetString(2);
                _a.responsible = _reader.GetString(3);
                _a.cost = _reader.GetDecimal(4);
                _a.CostMx = _reader.GetDecimal(5);
                _a.brand = _reader.GetString(6);
                _a.model = _reader.GetString(7);
                _a.serial = _reader.GetString(8);
                _a.invoice = _reader.GetString(9);
                if (_reader.IsDBNull(10))
                    _a.invoiceDate = null;
                else
                    _a.invoiceDate = _reader.GetDateTime(10);
                _a.pedimento = _reader.GetString(11);
                _a.codePedimento = _reader.GetString(12);
                _a.provider = _reader.GetString(13);
                _a.dateCreate = _reader.GetDateTime(14);
                _a.PO = _reader.GetString(15);
                _a.Owner = _reader.GetString(16);
                _a.notes = _reader.GetString(17);
                ListA.Add(_a);
            }
            _conn.Close();
            return ListA;
        }

        public List<JOINConsultAsset> ConsultAssetNormalLocation(string descrip, int location)
        {   
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULT_ASSETS_NORMAL_LOCATION", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@search", descrip);
            _command.Parameters.AddWithValue("@location", location);
            IDataReader _reader = _command.ExecuteReader();
            List<JOINConsultAsset> ListA = new List<JOINConsultAsset>();
            JOINConsultAsset _a;
            while (_reader.Read())
            {
                _a = new JOINConsultAsset();
                _a.id = _reader.GetInt32(0);
                _a.description = _reader.GetString(1);
                _a.location = _reader.GetString(2);
                _a.responsible = _reader.GetString(3);
                _a.cost = _reader.GetDecimal(4);
                _a.CostMx = _reader.GetDecimal(5);
                _a.brand = _reader.GetString(6);
                _a.model = _reader.GetString(7);
                _a.serial = _reader.GetString(8);
                _a.invoice = _reader.GetString(9);
                if (_reader.IsDBNull(10))
                    _a.invoiceDate = null;
                else
                    _a.invoiceDate = _reader.GetDateTime(10);
                _a.pedimento = _reader.GetString(11);
                _a.codePedimento = _reader.GetString(12);
                _a.provider = _reader.GetString(13);
                _a.dateCreate = _reader.GetDateTime(14);
                _a.PO = _reader.GetString(15);
                _a.Owner = _reader.GetString(16);
                _a.notes = _reader.GetString(17);
                ListA.Add(_a);
            }
            _conn.Close();
            return ListA;
        }

        public List<JOINConsultAsset> ConsultAssetNormalLocationOnly(int location)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULT_ASSETS_NORMAL_LOCATION_ONLY", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@location", location);
            IDataReader _reader = _command.ExecuteReader();
            List<JOINConsultAsset> ListA = new List<JOINConsultAsset>();
            JOINConsultAsset _a;
            while (_reader.Read())
            {
                _a = new JOINConsultAsset();
                _a.id = _reader.GetInt32(0);
                _a.description = _reader.GetString(1);
                _a.location = _reader.GetString(2);
                _a.responsible = _reader.GetString(3);
                _a.cost = _reader.GetDecimal(4);
                _a.CostMx = _reader.GetDecimal(5);
                _a.brand = _reader.GetString(6);
                _a.model = _reader.GetString(7);
                _a.serial = _reader.GetString(8);
                _a.invoice = _reader.GetString(9);
                if (_reader.IsDBNull(10))
                    _a.invoiceDate = null;
                else
                    _a.invoiceDate = _reader.GetDateTime(10);
                _a.pedimento = _reader.GetString(11);
                _a.codePedimento = _reader.GetString(12);
                _a.provider = _reader.GetString(13);
                _a.dateCreate = _reader.GetDateTime(14);
                _a.PO = _reader.GetString(15);
                _a.Owner = _reader.GetString(16);
                _a.notes = _reader.GetString(17);
                ListA.Add(_a);
            }
            _conn.Close();
            return ListA;
        }

        public List<AssetsBook> ConsultAssetsBooksAll()
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULT_ASSETSBOOK", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _command.ExecuteReader();
            List<AssetsBook> ListA = new List<AssetsBook>();
            AssetsBook _ab;
            while (_reader.Read())
            {
                _ab = new AssetsBook();
                _ab.idAB = _reader.GetInt32(0);
                _ab.partNumber = _reader.GetString(1);
                _ab.descrip = _reader.GetString(2);
                _ab.brand = _reader.GetString(3);
                _ab.model = _reader.GetString(4);
                _ab.serial = _reader.GetString(5);
                _ab.invoice = _reader.GetString(6);
                _ab.invoiceDate = _reader.GetDateTime(7);
                _ab.pedimento = _reader.GetString(8);
                _ab.codePedimento = _reader.GetString(9);
                _ab.provider = _reader.GetString(10);
                _ab.cost = _reader.GetDecimal(11);
                _ab.costmx = _reader.GetDecimal(12);
                _ab.PO = _reader.GetString(13);
                _ab.notes = _reader.GetString(14);
                _ab.owner = _reader.GetString(15);
                _ab.total = _reader.GetInt32(16);
                _ab.quantity = _reader.GetInt32(17);
                ListA.Add(_ab);
            }
            _conn.Close();
            return ListA;
        }
        
        public int SubtractAssetBook(int idAssetBook)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("SUBTRACT_ASSETSBOOK", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@id", idAssetBook);
            int result = _command.ExecuteNonQuery();
            _conn.Close();
            return result;
        }

        public List<AssetsBook> ConsultAssetsBooksSearch(string descrip)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULT_ASSETSBOOK_SEARCH", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@search", descrip);
            IDataReader _reader = _command.ExecuteReader();
            List<AssetsBook> ListA = new List<AssetsBook>();
            AssetsBook _ab;
            while (_reader.Read())
            {
                _ab = new AssetsBook();
                _ab.idAB = _reader.GetInt32(0);
                _ab.partNumber = _reader.GetString(1);
                _ab.descrip = _reader.GetString(2);
                _ab.brand = _reader.GetString(3);
                _ab.model = _reader.GetString(4);
                _ab.serial = _reader.GetString(5);
                _ab.invoice = _reader.GetString(6);
                _ab.invoiceDate = _reader.GetDateTime(7);
                _ab.pedimento = _reader.GetString(8);
                _ab.codePedimento = _reader.GetString(9);
                _ab.provider = _reader.GetString(10);
                _ab.cost = _reader.GetDecimal(11);
                _ab.costmx = _reader.GetDecimal(12);
                _ab.PO = _reader.GetString(13);
                _ab.notes = _reader.GetString(14);
                _ab.owner = _reader.GetString(15);
                _ab.total = _reader.GetInt32(16);
                _ab.quantity = _reader.GetInt32(17);
                ListA.Add(_ab);
            }
            _conn.Close();
            return ListA;
        }

        public int ConsultAssetsTotal()
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULT_COUNT_TOTAL", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _command.ExecuteReader();
            int count = 0;
            while (_reader.Read())
            {
                count = _reader.GetInt32(0);
            }
            _conn.Close();
            return count;
        }

        public List<JOINConsultAsset> ConsultAssetsTop100()
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULT_ASSETS_TOP_100", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _command.ExecuteReader();
            List<JOINConsultAsset> ListA = new List<JOINConsultAsset>();
            JOINConsultAsset _a;
            while (_reader.Read())
            {
                _a = new JOINConsultAsset();
                _a.id = _reader.GetInt32(0);
                _a.description = _reader.GetString(1);
                _a.location = _reader.GetString(2);
                _a.responsible = _reader.GetString(3);
                _a.cost = _reader.GetDecimal(4);
                _a.CostMx = _reader.GetDecimal(5);
                _a.brand = _reader.GetString(6);
                _a.model = _reader.GetString(7);
                _a.serial = _reader.GetString(8);
                _a.invoice = _reader.GetString(9);
                if (_reader.IsDBNull(10))
                    _a.invoiceDate = null;
                else
                    _a.invoiceDate = _reader.GetDateTime(10);
                _a.pedimento = _reader.GetString(11);
                _a.codePedimento = _reader.GetString(12);
                _a.provider = _reader.GetString(13);
                _a.dateCreate = _reader.GetDateTime(14);
                _a.PO = _reader.GetString(15);
                _a.Owner = _reader.GetString(16);
                _a.notes = _reader.GetString(17);
                ListA.Add(_a);

            }
            _conn.Close();
            return ListA;
        }

        public int UpdatePictureGroup(string name, int num)
        {
            IDbConnection _conn = DBComon.Connectiondb();
            _conn.Open();
            SqlCommand _command = new SqlCommand("UPDATE_PICTURE", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@id", num);
            _command.Parameters.AddWithValue("@pic", name);
            int result = _command.ExecuteNonQuery();
            _conn.Close();
            return result;
        }
    }
}
