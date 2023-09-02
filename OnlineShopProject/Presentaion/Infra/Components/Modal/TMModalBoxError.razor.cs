using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Modal
{
    public partial class TMModalBoxError
    {

        /// <summary>
        /// عنوان مدال
        /// </summary>
        [Parameter] public string Title { get; set; }
        /// <summary>
        /// عنوان دکمه
        /// </summary>
        [Parameter] public string ConfirmButtonText { get; set; } = "OK";
        /// <summary>
        /// آیکن مدال
        /// </summary>
        [Parameter] public string Icon { get; set; } = "bx-x";
        /// <summary>
        /// توضیحات مدال
        /// </summary>
        [Parameter] public string? Message { get; set; }
        /// <summary>
        /// انیمیشن مدال - پیشفرض فعال
        /// </summary>
        [Parameter] public bool FadeModalAnimation { get; set; } = true;

        /// <summary>
        /// نمایش زمینه مدال - پیشفرض فعال
        /// </summary>
        [Parameter] public bool DisableBackdrop { get; set; } = false;

        /// <summary>
        /// نمایش آیکن مدال - پیشفرض فعال
        /// </summary>
        [Parameter] public bool HideIcon { get; set; } = false;
        /// <summary>
        /// دریافت بازخورد دکمه ارسال
        /// </summary>
        [Parameter] public EventCallback Confirm { get; set; }
        /// <summary>
        /// btn-primary - کلاس دکمه  
        /// </summary>
        [Parameter] public string ConfirmButtonClass { get; set; } = "btn-primary";
        /// <summary>
        ///   نمایش محتوای Html   
        /// </summary>
        [Parameter] public RenderFragment BodyHtmlContent { get; set; }

        /// <summary>
        /// نمایش دکمه ارسال
        /// </summary>
        [Parameter] public bool ShowConfirmButton { get; set; } = true;
        /// <summary>
        /// سایز فونت عنوان - پیشفرض 22
        /// </summary>
        [Parameter] public int TitleFontSize { get; set; } = 22;


        /// <summary>
        /// غیرفعال کردن حالت مرکزی مدال
        /// </summary>
        /// 
        [Parameter]
        public bool DisableCentered { get; set; } = true;

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
            ModalClass = "hide";
            Backdrop = false;
            StateHasChanged();
            //   CloseModal.InvokeAsync();
        }

        public void CloseAndDispose()
        {
            DisposeModal = true;
            ModalDisplay = "none";
            ModalClass = "";
            Backdrop = false;
            StateHasChanged();
            // await CloseModal.InvokeAsync();
        }
    }
}
