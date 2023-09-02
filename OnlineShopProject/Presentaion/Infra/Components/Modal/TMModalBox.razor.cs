using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Modal
{
    public partial class TMModalBox
    {
        /// <summary>
        /// غیر فعال کردن نمایش هدر 
        /// </summary>
        [Parameter] public bool HideHeader { get; set; } = false;
        /// <summary>
        /// عنوان در هدر
        /// </summary>
        [Parameter] public string? HeaderTitle { get; set; }
        /// <summary>
        /// کلاس های استایل برای هدر
        /// </summary>
        [Parameter] public string? HeaderCssClass { get; set; }
        /// <summary>
        /// غیرفعال کردن نمایش فوتر  
        /// </summary>
        [Parameter] public bool HideFooter { get; set; } = false;
        /// <summary>
        /// غیرفعال کردن زمینه مدال 
        /// </summary>
        [Parameter] public bool DisableBackdrop { get; set; } = false;


        /// <summary>
        /// پنهان کردن نمایش عنوان در هدر
        /// </summary>
        [Parameter] public bool HideHeaderTitle { get; set; }
        /// <summary>
        /// عنوان دکمه انصراف 
        /// </summary>
        [Parameter] public string? CancelButtonName { get; set; } = "Cancel";

        [Parameter] public string? CancelButtonIcon { get; set; }
        /// <summary>
        /// استایل دکمه انصراف
        /// </summary>
        [Parameter] public string? CancelButtonCssClass { get; set; } = "btn-danger";

        /// <summary>
        /// عنوان دکمه تایید
        /// </summary>
        [Parameter] public string? ConfirmedButtonName { get; set; } = "Confirm";

        /// <summary>
        /// دریافت بازخورد دکمه انصراف
        /// </summary>
        [Parameter] public EventCallback Cancel { get; set; }

        /// <summary>
        /// دریافت بازخورد دکمه تایید
        /// </summary>
        [Parameter] public EventCallback Confirm { get; set; }

        /// <summary>
        /// فعال سازی انیمیشن مدال - پیشفرض فعال
        /// </summary>
        [Parameter] public bool FadeModalAnimation { get; set; }

        /// <summary>
        /// پنهان کردن دکمه انصراف
        /// </summary>
        [Parameter] public bool HideCanselButton { get; set; } = false;

        /// <summary>
        /// نمایش دکمه تایید
        /// </summary>
        [Parameter] public bool HideConfirmButton { get; set; } = false;

        /// <summary>
        /// کلاس دکمه تایید
        /// </summary>
        [Parameter] public string ConfirmButtonCssClass { get; set; } = "btn-primary";

        /// <summary>
        /// آیکن دکمه تایید
        /// </summary>
        [Parameter] public string? ConfirmButtonIcon { get; set; }


        /// <summary>
        /// محتوای Html در هدر
        /// </summary>
        [Parameter] public RenderFragment? HeaderHtmlContent { get; set; }
        /// <summary>
        ///  نمایش محتوای Html      
        /// </summary>
        [Parameter] public RenderFragment? BodyHtmlContent { get; set; }

        /// <summary>
        ///  اسکرین مدال
        /// </summary>
        [Parameter] public FullscreenModal fullScreenModal { get; set; } = FullscreenModal.ModalFullScreenOff;

        /// <summary>
        /// اندازه مدال 
        /// </summary>
        [Parameter] public ModalSize Size { get; set; } = ModalSize.ModalSm;
        /// <summary>
        /// اندازه فونت عنوان 
        /// </summary>
        [Parameter] public int TitleFontSize { get; set; } = 22;

        /// <summary>
        /// غیرفعال کردن حالت مرکزی مدال
        /// </summary>
        /// 
        [Parameter]
        public bool DisableCentered { get; set; } = true;


        public string FullScreenClass { get; set; } = "";
        public bool DisposeModal { get; set; }
        public string ModalClass { get; set; } = "fade";
        public string ModalSizeClass { get; set; } = "";
        public string ModalDisplay = "none;";
        public bool Backdrop = false;
        public async Task Open()
        {
            await Task.Run(() =>
              {
                  DisposeModal = false;
                  ModalDisplay = "block";
                  ModalClass = "show";
                  Backdrop = true;
                  StateHasChanged();
              });

            //  await Confirm.InvokeAsync();
        }

        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "hide";
            Backdrop = false;
            StateHasChanged();
            //   CloseModal.InvokeAsync();
        }

        public async Task CloseAndDispose()
        {
            DisposeModal = true;
            ModalDisplay = "none";
            ModalClass = "";
            Backdrop = false;
            StateHasChanged();
            await Cancel.InvokeAsync();
        }

        public enum ModalSize
        {
            Defoult,
            ModalXl,
            ModalLg,
            ModalSm
        }

        public enum FullscreenModal
        {
            ModalFullscreen,
            ModalFullscreenSmDown,
            ModalFullscreenMdDown,
            ModalFullscreenLgDown,
            ModalFullscreenXlDown,
            ModalFullscreenXxlDown,
            ModalFullScreenOff
        }

        protected override void OnInitialized()
        {
            switch (fullScreenModal)
            {
                case FullscreenModal.ModalFullscreen:
                    FullScreenClass = "modal-fullscreen";
                    break;
                case FullscreenModal.ModalFullscreenSmDown:
                    FullScreenClass = "modal-fullscreen-sm-down";
                    break;
                case FullscreenModal.ModalFullscreenMdDown:
                    FullScreenClass = "modal-fullscreen-md-down";
                    break;
                case FullscreenModal.ModalFullscreenLgDown:
                    FullScreenClass = "modal-fullscreen-lg-down";
                    break;
                case FullscreenModal.ModalFullscreenXlDown:
                    FullScreenClass = "modal-fullscreen-xl-down";
                    break;
                case FullscreenModal.ModalFullscreenXxlDown:
                    FullScreenClass = "modal-fullscreen-xxl-down";
                    break;
                case FullscreenModal.ModalFullScreenOff:
                    FullScreenClass = "";
                    break;
                default:
                    FullScreenClass = "";
                    break;
            }

            switch (Size)
            {
                case ModalSize.Defoult:
                    ModalSizeClass = "";
                    break;
                case ModalSize.ModalSm:
                    ModalSizeClass = "modal-sm";
                    break;
                case ModalSize.ModalLg:
                    ModalSizeClass = "modal-lg";
                    break;
                case ModalSize.ModalXl:
                    ModalSizeClass = "modal-xl";
                    break;
            }
        }
    }
}
