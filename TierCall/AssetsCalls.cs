using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TierEntities;
using TierAgreements;

namespace TierCall
{
    public class AssetsCalls
    {
        AssetsAgreements _AssetsA = new AssetsAgreements();

        public int AddAsset(Asset AssetE)
        {
            return _AssetsA.AddAsset(AssetE);
        }

        public int LastId()
        {
            return _AssetsA.LastId();
        }

        public int UpdatePicture(Asset AssetE)
        {
            return _AssetsA.UpdatePicture(AssetE);
        }

        public int UpdateAsset(Asset AssetE)
        {
            return _AssetsA.UpdateAsset(AssetE);
        }

        public Asset SearchAsset(Asset AssetE)
        {
            return _AssetsA.SearchAsset(AssetE);
        }

        public List<JOINConsultAsset> ConsultAllAssetVisible()
        {
            return _AssetsA.ConsultAllAssetVisible();
        }

        public int SearchId(Asset AssetE)
        {
            return _AssetsA.SearchId(AssetE);
        }

        public int RemoveAsset(Asset AssetE)
        {
            return _AssetsA.RemoveAsset(AssetE);
        }

        public List<string> FillResponsible()
        {
            return _AssetsA.FillResponsible();
        }

        public List<string> FillLocation()
        {
            return _AssetsA.FillLocation();
        }

        public List<JOINConsultAsset> ConsultAssetNormal(string search)
        {
            return _AssetsA.ConsultAssetNormal(search);
        }

        public List<JOINConsultAsset> ConsultAssetNormalLocation(string search, int location)
        {
            return _AssetsA.ConsultAssetNormalLocation(search, location);
        }

        public List<AssetsBook> ConsultAssetsBookAll()
        {
            return _AssetsA.ConsultAssetsBooksAll();
        }

        public int SubtractAssetsBook(int idAssetBook)
        {
            return _AssetsA.SubtractAssetBook(idAssetBook);
        }

        public List<AssetsBook> ConsultAssetsBooksSearch(string search)
        {
            return _AssetsA.ConsultAssetsBooksSearch(search);
        }

        public List<JOINConsultAsset> ConsultAssetNormalLocationOnly (int location)
        {
            return _AssetsA.ConsultAssetNormalLocationOnly(location);
        }

        public List<JOINConsultAsset> ConsultAssetTop100()
        {
            return _AssetsA.ConsultAssetsTop100();
        }

        public int ConsultAssetsTotal()
        {
            return _AssetsA.ConsultAssetsTotal();
        }

        public int UpdatePictureGroup(string name, int num)
        {
            return _AssetsA.UpdatePictureGroup(name, num);
        }
    }
}
