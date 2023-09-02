using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Modal
{
    public partial class TMModalBoxAlert
    {
        /// <summary>
        /// فعال سازی هدر
        /// </summary>
        [Parameter] public bool HideHeader { get; set; }
        /// <summary>
        /// عنوان مدال
        /// </summary>
        [Parameter] public string Title { get; set; }
        /// <summary>
        /// فعال سازی انیمیشن مدال - پیشفرض فعال
        /// </summary>
        [Parameter] public bool FadeModalAnimation { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        [Parameter] public string Message { get; set; }
        /// <summary>
        /// فعال سازی فوتر مدال - پیشفرض فعال
        /// </summary>
        [Parameter] public bool HideFooter { get; set; } = false;

        /// <summary>
        /// فعال سازی نمایش زمینه مدال - پیشفرض فعال
        /// </summary>
        [Parameter] public bool DisableBackdrop { get; set; } = false;
        /// <summary>
        ///  نمایش محتوای Html                
        /// </summary>
        [Parameter] public RenderFragment BodyHtmlContent { get; set; }
        /// <summary>
        /// دریافت بازخورد ثبت
        /// </summary>
        [Parameter] public EventCallback Confirm { get; set; }
        /// <summary>
        /// عنوان دکمه انصراف
        /// </summary>
        [Parameter] public string ConfirmButtonText { get; set; } = "بستن";
        /// <summary>
        /// bxs-alarm-exclamation آیکن مدال - پیشفرض 
        /// </summary>
        [Parameter] public string Icon { get; set; } = "bxs-alarm-exclamation";

        public bool DefultFooter { get; set; } = true;

        /// <summary>
        /// غیرفعال کردن حالت مرکزی مدال
        /// </summary>
        /// 
        [Parameter]
        public bool DisableCentered { get; set; } = true;

        /// <summary>
        /// اندازه فونت عنوان - پیشفرض 22
        /// </summary>
        [Parameter] public int TitleFontSize { get; set; } = 22;

        public bool DisposeModal { get; set; }
        public bool Backdrop = false;
        public string ModalDisplay = "none;";
        public string ModalClass { get; set; } = "fade";
        public void Open()
        {
            DisposeModal = false;
            ModalDisplay = "block";
            ModalClass = "show";
            Backdrop = true;
            StateHasChanged();
            //  await SubmitModal.InvokeAsync();
        }

        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            Backdrop = false;
            StateHasChanged();
            //   CloseModal.InvokeAsync();
        }

        public async Task CloseAndDispose()
        {
            await Task.Run(() =>
            {
                DisposeModal = true;
                ModalDisplay = "none";
                ModalClass = "";
                Backdrop = false;
                StateHasChanged();
            });

            //  await CloseModal.InvokeAsync();
        }
    }
}
