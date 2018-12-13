using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TierEntities;
using TierAgreements;

namespace TierCall
{
    public class ChangeAssetsCalls
    {
        ChangeAssetsAgreements _changeAC = new ChangeAssetsAgreements();
        Asset AssetE = new Asset();
        
        public int AddChangeAsset(ChangeAssets ChangeAE)
        {
            return _changeAC.AddChangeAsset(ChangeAE);
        }

        public List<ChangeAssets> ConsultAllAssetVisible(Asset AssetE)
        {
            return _changeAC.ConsultAllAssetVisible(AssetE);
        }

        public List<JOINChange> ConsultAllAssetChange(Asset AssetE)
        {
            return _changeAC.ConsultAllAssetChange(AssetE);
        }
    }
}
