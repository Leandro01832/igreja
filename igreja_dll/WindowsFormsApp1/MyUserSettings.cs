using System.Configuration;
using System.Drawing;

namespace WindowsFormsApp1
{
    public  class MyUserSettings : ApplicationSettingsBase
    {
        public MyUserSettings(FrmPrincipal form)
        {
            Form = form;
        }

        public FrmPrincipal Form { get; }

        [UserScopedSetting()]
        [DefaultSettingValue("white")]
        public Color BackgroundColorPrincipal
        {
            get
            {
                return ((Color)this["BackgroundColorPrincipal"]);
            }
            set
            {
                this["BackgroundColorPrincipal"] = (Color)value;
                Form.BackColor = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("white")]
        public Color BackgroundColorGereciamentoPessoa
        {
            get
            {
                return ((Color)this["BackgroundColorGereciamentoPessoa"]);
            }
            set
            {
                this["BackgroundColorGereciamentoPessoa"] = (Color)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("white")]
        public Color BackgroundColorFinanceiro
        {
            get
            {
                return ((Color)this["BackgroundColorFinanceiro"]);
            }
            set
            {
                this["BackgroundColorFinanceiro"] = (Color)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("white")]
        public Color BackgroundColorEsboco
        {
            get
            {
                return ((Color)this["BackgroundColorEsboco"]);
            }
            set
            {
                this["BackgroundColorEsboco"] = (Color)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("white")]
        public Color BackgroundColorEmail
        {
            get
            {
                return ((Color)this["BackgroundColorEmail"]);
            }
            set
            {
                this["BackgroundColorEmail"] = (Color)value;
            }
        }

    }
}
