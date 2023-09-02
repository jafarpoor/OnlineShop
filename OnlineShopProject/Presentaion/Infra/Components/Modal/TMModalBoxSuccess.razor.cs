using Microsoft.AspNetCore.Components;

namespace Components.Modal
{
    public partial class TMModalBoxSuccess
    {
        /// <summary>
        /// عنوان 
        /// </summary>
        [Parameter] public string Title { get; set; } //= Resx.Shared.SuccessSaveMsg;
        /// <summary>
        /// توضیحات
        /// </summary>
        [Parameter] public string Message { get; set; }
        /// <summary>
        /// آیکن Modal - پیشفرض bx-check فعال است
        /// </summary>
        [Parameter] public string Icon { get; set; } = "bx-check";

        /// <summary>
        /// حالت انیمیشن مدال - پیشفرض فعال است
        /// </summary>
        [Parameter] public bool FadeModalAnimation { get; set; } = true;
        /// <summary>
        /// زمان بسته شدن مدال - پیشفرض 2500
        /// </summary>
        [Parameter] public int Timer { get; set; } = 2500;

        /// <summary>
        /// نمایش محتوای Html 
        /// </summary>
        [Parameter] public RenderFragment BodyHtmlContent { get; set; }

        /// <summary>
        /// پنهان کردن آیکن
        /// </summary>
        [Parameter] public bool HideIcon { get; set; }

        /// <summary>
        /// اندازه فونت عنوان- پیشفرض 26
        /// </summary>
        [Parameter] public int TitleFontSize { get; set; } = 26;

        /// <summary>
        /// غیرفعال کردن حالت مرکزی مدال
        /// </summary>
        /// 
        [Parameter]
        public bool DisableCentered { get; set; } = true;

        public bool DisposeModal { get; set; }
        public string ModalClass { get; set; } = "fade";

        public string ModalDisplay = "none;";

        public bool Backdrop = false;
        public static Task timer = Task.Run(async delegate
        {
            await Task.Delay(2000);
        });

        public async Task Open()
        {
            DisposeModal = false;
            ModalDisplay = "block";
            ModalClass = "show";
            Backdrop = false;
            StateHasChanged();
            await Task.Delay(Timer);
            Close();

        }

        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "hide";
            Backdrop = false;
            StateHasChanged();

        }

        public void CloseAndDispose()
        {
            DisposeModal = true;
            ModalDisplay = "none";
            ModalClass = "";
            Backdrop = false;
            StateHasChanged();
        }
    }
}
