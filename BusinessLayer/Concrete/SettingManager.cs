using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SettingManager : ISettingService
    {
        ISettingDal _settingDal;

        public SettingManager(ISettingDal settingDal)
        {
            _settingDal = settingDal;
        }

        public Setting GetSetting()
        {
            return _settingDal.Get(x => x.SettingID == 1);
        }

        public void UpdateSettingBl(Setting setting)
        {
            _settingDal.Update(setting);
        }
    }
}
