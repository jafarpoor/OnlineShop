using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Modal
{
    public partial class TMModalBoxInfomation
    {
        /// <summary>
        /// عنوان مدال باکس
        /// </summary>
        [Parameter] public string Title { get; set; }
        /// <summary>
        /// سایز فونت عنوان مدال باکس - پیشفرض 22
        /// </summary>
        [Parameter] public int TitleFontSize { get; set; } = 22;

        /// <summary>
        /// عنوان دکمه
        /// </summary>
        [Parameter] public string ConfirmButtonText { get; set; } = "OK";
        /// <summary>
        /// آیکن مدال باکس - پیشفرض bx-info-circle
        /// </summary>
        [Parameter] public string Icon { get; set; } = "bx-info-circle";

        /// <summary>
        ///btn-info کلاس دکمه ثبت - پیشفرض 
        /// </summary>
        [Parameter] public string ConfirmButtonClass { get; set; } = "btn-info";

        /// <summary>
        /// توضیحات بیشتر برای نمایش در بدنه مدال
        /// </summary>
        [Parameter] public string? Message { get; set; }

        /// <summary>
        /// فعال سازی حالت انمیشن مدال - پیشفرض فعال
        /// </summary>
        [Parameter] public bool FadeModalAnimation { get; set; } = true;

        /// <summary>
        /// نمایش پس زمینه مدال - پیشفرض فعال
        /// </summary>
        [Parameter] public bool DisableBackdrop { get; set; } = false;
        /// <summary>
        /// نمایش آیکن - پیشفرض فعال
        /// </summary>
        [Parameter] public bool ShowIcon { get; set; } = true;

        /// <summary>
        ///   نمایش محتوای Html 
        /// </summary>
        [Parameter] public RenderFragment? BodyHtmlContent { get; set; }

        /// <summary>
        /// دریافت بازخورد دکمه انصراف
        /// </summary>
        [Parameter] public EventCallback Cancel { get; set; }

        /// <summary>
        /// دریافت باز خورد دکمه دکمه ارسال
        /// </summary>
        [Parameter] public EventCallback Confirm { get; set; }


        [Parameter] public bool HideCanselButton { get; set; } = false;

        /// <summary>
        /// غیرفعال کردن حالت مرکزی مدال
        /// </summary>
        /// 
        [Parameter]
        public bool DisableCentered { get; set; } = true;


        public bool DisposeModal { get; set; }
        public string ModalAnimationClass { get; set; } = "fade";
        public bool Backdrop = false;
        public string ModalDisplay = "none;";

        public async Task Open()
        {
            await Task.Run(() =>
            {
                DisposeModal = false;
                ModalDisplay = "block";
                ModalAnimationClass = "show";
                Backdrop = true;
                StateHasChanged();
            });
            //  await SubmitModal.InvokeAsync();
        }

        public void Close()
        {
            ModalDisplay = "none";
            ModalAnimationClass = "hide";
            Backdrop = false;
            StateHasChanged();
            //   CloseModal.InvokeAsync();
        }

        public void CloseAndDispose()
        {
            DisposeModal = true;
            ModalDisplay = "none";
            ModalAnimationClass = "";
            Backdrop = false;
            StateHasChanged();
            // await CloseModal.InvokeAsync();
        }
    }
}
