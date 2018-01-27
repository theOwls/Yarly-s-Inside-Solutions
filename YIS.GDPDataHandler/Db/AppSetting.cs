using System.ComponentModel.DataAnnotations;

namespace YIS.GDPDataHandler.Db
{
    public class AppSetting
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
