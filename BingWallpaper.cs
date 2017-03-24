using System;
using System.Collections;
using System.Collections.Generic;

namespace TomatoClock
{
    public class BingWallpaper
    {
        public string Url { get; set; }
        public string Title { get; set; }

        public BingWallpaper(string url, string title)
        {
            if (!url.StartsWith("http://"))
            {
                url = "http://www.bing.com" + url;
            }
            this.Url = url;
            this.Title = title;
        }

        public static BingWallpaper[] getBingWallpaperUrl(int idx, int n = 1)
        {
            string bingWallpaper = "http://www.bing.com/HPImageArchive.aspx?format=js&idx={0}&n={1}&mkt=zh-CN";
            string imgurl = String.Format(bingWallpaper, idx, n);
            string html = Helper.HttpDownloadHtml(imgurl);
            Dictionary<string, object> json = Helper.JsonToDictionary(html);
            ArrayList imgs = json["images"] as ArrayList;

            List<BingWallpaper> result = new List<BingWallpaper>();
            foreach (Dictionary<string, object> img in imgs)
            {
                string url = img["url"] as string;
                string title = "";
                if (img.ContainsKey("msg"))
                    title = ((img["msg"] as ArrayList)[0] as Dictionary<string, object>)["text"] as string;
                else if (img.ContainsKey("copyright"))
                    title = (img["copyright"] as string).Split(' ')[0];
                result.Add(new BingWallpaper(url, title));
            }
            return result.ToArray();
        }
    }
}
