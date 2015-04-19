
namespace YDT.WinForm.UCBase
{
    using System;
    using System.ComponentModel;
    using WeifenLuo.WinFormsUI.Docking;

    public partial class DockPanelEx : WeifenLuo.WinFormsUI.Docking.DockPanel
    {
        #region Constructure

        public DockPanelEx()
        {
            InitializeComponent();
        }

        public DockPanelEx(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        #endregion

        #region Public Method
        /// <summary>
        /// ShowContent
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="formType"></param>
        /// <param name="dockState"></param>
        /// <returns></returns>
        public DockContent ShowContent(string caption, Type formType, DockState dockState = DockState.Document)
        {
            DockContent frm = FindDocument(caption);
            if (frm == null)
            {
                frm = Activator.CreateInstance(formType) as DockContent;
                if (frm == null)
                {
                    return null;
                }
                frm.DockHandler.TabText = caption;
                frm.Show(this, dockState);
            }
            else
            {
                frm.Show(this, dockState);
                frm.BringToFront();
            }
            return frm;
        }
        /// <summary>
        /// Shows the content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="dockState">State of the dock.</param>
        /// <returns></returns>
        public DockContent ShowContent(DockContent content, DockState dockState)
        {
            DockContent frm = FindDocument(content.Text);

            if (frm == null)
            {
                content.Tag = content.Text;
                content.Show(this, dockState);
            }
            else
            {
                frm.Show(this, dockState);
                frm.BringToFront();
            }
            return frm;
        }
        /// <summary>
        /// Shows the content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public DockContent ShowContent(DockContent content)
        {
            return ShowContent(content, content.DockState == DockState.Unknown ?
                DockState.DockBottomAutoHide : content.DockState);
        }

        public DockContent FindActiveDocument()
        {
            if (this.DocumentStyle == DocumentStyle.SystemMdi)
            {
                //foreach (Form form in MdiChildren)
                //{
                //    if (form.Text == text)
                //    {
                //        return form as DockContent;
                //    }
                //}
                return null;
            }
            else
            {
                foreach (DockContent content in this.Documents)
                {
                    if (content.IsActivated)
                        return content;
                }
                return null;
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// FindDocument
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private DockContent FindDocument(string text)
        {
            if (this.DocumentStyle == DocumentStyle.SystemMdi)
            {
                //foreach (Form form in MdiChildren)
                //{
                //    if (form.Text == text)
                //    {
                //        return form as DockContent;
                //    }
                //}
                return null;
            }
            else
            {
                foreach (DockContent content in this.Documents)
                {
                    if (content.Tag.Equals(text))
                        return content;
                }
                return null;
            }
        }
        #endregion

    }
}
