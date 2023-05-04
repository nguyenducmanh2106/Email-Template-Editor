using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Business.Email
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Action
    {
        public string name { get; set; }
        public Values values { get; set; }
    }

    public class Attrs
    {
        public string href { get; set; }
        public string target { get; set; }
        public string onClick { get; set; }
    }

    public class BackgroundImage
    {
        public string url { get; set; }
        public bool fullWidth { get; set; }
        public string repeat { get; set; }
        public string size { get; set; }
        public string position { get; set; }
    }

    public class Body
    {
        public string id { get; set; }
        public List<Row> rows { get; set; }
        public Values values { get; set; }
    }

    public class Border
    {
        public string borderTopWidth { get; set; }
        public string borderTopStyle { get; set; }
        public string borderTopColor { get; set; }
        public string borderLeftColor { get; set; }
        public string borderLeftStyle { get; set; }
        public string borderLeftWidth { get; set; }
        public string borderRightColor { get; set; }
        public string borderRightStyle { get; set; }
        public string borderRightWidth { get; set; }
        public string borderBottomColor { get; set; }
        public string borderBottomStyle { get; set; }
        public string borderBottomWidth { get; set; }
    }

    public class ButtonColors
    {
        public string color { get; set; }
        public string backgroundColor { get; set; }
        public string hoverColor { get; set; }
        public string hoverBackgroundColor { get; set; }
    }

    public class Column
    {
        public string id { get; set; }
        public List<Content> contents { get; set; }
        public Values values { get; set; }
    }

    public class Content
    {
        public string id { get; set; }
        public string type { get; set; }
        public Values values { get; set; }
    }

    public class Counters
    {
        public int u_row { get; set; }
        public int u_column { get; set; }
        public int u_content_menu { get; set; }
        public int u_content_text { get; set; }
        public int u_content_image { get; set; }
        public int u_content_button { get; set; }
        public int u_content_divider { get; set; }
        public int u_content_heading { get; set; }
    }

    public class FontFamily
    {
        public string label { get; set; }
        public string value { get; set; }
        public string url { get; set; }
        public object weights { get; set; }
        public bool defaultFont { get; set; }
    }

    public class Href
    {
        public string name { get; set; }
        public Values values { get; set; }
    }

    public class Item
    {
        public string key { get; set; }
        public Link link { get; set; }
        public string text { get; set; }
    }

    public class Link
    {
        public string name { get; set; }
        public Attrs attrs { get; set; }
        public Values values { get; set; }
    }

    public class LinkStyle
    {
        public bool inherit { get; set; }
        public string linkColor { get; set; }
        public string linkHoverColor { get; set; }
        public bool linkUnderline { get; set; }
        public bool linkHoverUnderline { get; set; }
        public bool? body { get; set; }
    }

    public class Menu
    {
        public List<Item> items { get; set; }
    }

    public class Meta
    {
        public string htmlID { get; set; }
        public string htmlClassNames { get; set; }
    }

    public class Mobile
    {
        public Src src { get; set; }
        public string fontSize { get; set; }
        public string textAlign { get; set; }
        public string lineHeight { get; set; }
        public string layout { get; set; }
        public Border border { get; set; }
    }

    public class Override
    {
        public Mobile mobile { get; set; }
    }

    public class PopupBackgroundImage
    {
        public string url { get; set; }
        public bool fullWidth { get; set; }
        public string repeat { get; set; }
        public string size { get; set; }
        public string position { get; set; }
    }

    public class PopupCloseButtonAction
    {
        public string name { get; set; }
        public Attrs attrs { get; set; }
    }

    public class Root
    {
        public Counters counters { get; set; }
        public Body body { get; set; }
        public int schemaVersion { get; set; }
    }

    public class Row
    {
        public string id { get; set; }
        public List<int> cells { get; set; }
        public List<Column> columns { get; set; }
        public Values values { get; set; }
    }

    public class Size
    {
        public bool autoWidth { get; set; }
        public string width { get; set; }
    }

    public class Src
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string maxWidth { get; set; }
        public bool autoWidth { get; set; }
    }

    public class Values
    {
        public string containerPadding { get; set; }
        public string anchor { get; set; }
        public Src src { get; set; }
        public string textAlign { get; set; }
        public string altText { get; set; }
        public Action action { get; set; }
        public bool hideDesktop { get; set; }
        public object displayCondition { get; set; }
        public Meta _meta { get; set; }
        public bool selectable { get; set; }
        public bool draggable { get; set; }
        public bool duplicatable { get; set; }
        public bool deletable { get; set; }
        public bool hideable { get; set; }
        public Override _override { get; set; }
        public string headingType { get; set; }
        public int? fontWeight { get; set; }
        public string fontSize { get; set; }
        public string color { get; set; }
        public string lineHeight { get; set; }
        public LinkStyle linkStyle { get; set; }
        public string text { get; set; }
        public Href href { get; set; }
        public ButtonColors buttonColors { get; set; }
        public Size size { get; set; }
        public string padding { get; set; }
        public Border border { get; set; }
        public string borderRadius { get; set; }
        public int? calculatedWidth { get; set; }
        public int? calculatedHeight { get; set; }
        public Menu menu { get; set; }
        public string textColor { get; set; }
        public string linkColor { get; set; }
        public string align { get; set; }
        public string layout { get; set; }
        public string separator { get; set; }
        public string width { get; set; }
        public string target { get; set; }
        public string backgroundColor { get; set; }
        public bool columns { get; set; }
        public string columnsBackgroundColor { get; set; }
        public BackgroundImage backgroundImage { get; set; }
        public string popupPosition { get; set; }
        public string popupWidth { get; set; }
        public string popupHeight { get; set; }
        public string contentAlign { get; set; }
        public string contentVerticalAlign { get; set; }
        public int contentWidth { get; set; }
        public FontFamily fontFamily { get; set; }
        public string popupBackgroundColor { get; set; }
        public PopupBackgroundImage popupBackgroundImage { get; set; }
        public string popupOverlay_backgroundColor { get; set; }
        public string popupCloseButton_position { get; set; }
        public string popupCloseButton_backgroundColor { get; set; }
        public string popupCloseButton_iconColor { get; set; }
        public string popupCloseButton_borderRadius { get; set; }
        public string popupCloseButton_margin { get; set; }
        public PopupCloseButtonAction popupCloseButton_action { get; set; }
        public string preheaderText { get; set; }
    }



}
