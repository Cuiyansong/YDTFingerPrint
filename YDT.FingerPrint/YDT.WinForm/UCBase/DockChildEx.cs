
namespace YDT.WinForm.UCBase
{
    public partial class DockChildEx : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region Constructor
        public DockChildEx()
        {
            InitializeComponent();
            // this.HideOnClose = true;
            // this.CloseButtonVisible = false;
            this.AllowEndUserDocking = false;
        }
        #endregion
    }
}
