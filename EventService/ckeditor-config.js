/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function(config) {
  config.ignoreConfirmCancel = true;
  // config.removePlugins = 'image';
  config.removePlugins = "elementspath";
  config.resize_enabled = false;
  // config.skin = 'v2';
  // config.toolbarCanCollapse = false; //change for collapsible toolbar true = on
  // config.toolbarStartupExpanded = true; //change for collapsible toolbar false = on
  config.enterMode = CKEDITOR.ENTER_BR;
  config.startupFocus = false;
  config.language = "en";
  config.AutoDetectLanguage = false;

  config.disableNativeSpellChecker = false;
  config.forcePasteAsPlainText = true;

  config.forceSimpleAmpersand = true;

  // config.removePlugins = 'about,a11yhelp,bidi,blockquote,button,colorbutton,colordialog,dialogadvtab,div,filebrowser,find,flash,font,forms,iframe,indent,newpage,preview,print,smiley,showblocks,showborders,table,tabletools,templates,elementspath,popup,entities,pagebreak,scayt,stylescombo,wsc,panelbutton,removeformat,pastefromword,save';

  config.removeFormatTags = "b,p,big,code,del,dfn,em,font,i,ins,kbd,input,style";

  config.whitelist_elements = {
    p: { attributes: { align: 1, title: 1 } },
    br: 1,
    strong: 1,
    b: 1,
    em: 1,
    i: 1,
    ol: { attributes: { type: 1, start: 1 } },
    ul: { attributes: { type: 1 } },
    li: { attributes: { type: 1, value: 1 } },
    sub: 1,
    sup: 1,
    img: { attributes: { src: 1, alt: 1, align: 1, border: 1, height: 1, width: 1 } },
    a: { attributes: { href: 1, target: 1 } },
    hr: { attributes: { align: 1, noshade: 1, size: 1, width: 1, color: 1 } },
    font: { attributes: { color: 1 } },
    u: 1
  };

  config.whitelist_globalAttributes = {
    id: 1
  };

  config.toolbarGroups = [
    { name: "basicstyles", groups: ["basicstyles", "cleanup"] },
    { name: "paragraph", groups: ["list", "indent", "blocks", "align", "bidi", "paragraph"] },
    { name: "links", groups: ["links"] },
    { name: "insert", groups: ["insert"] },
    { name: "document", groups: ["mode", "document", "doctools"] },
    { name: "tools", groups: ["tools"] },
    { name: "about", groups: ["about"] }
  ];

  config.removeButtons =
    "Underline,Strike,Subscript,Superscript,CopyFormatting,RemoveFormat,Outdent,Indent,Blockquote,CreateDiv,JustifyLeft,JustifyCenter,JustifyRight,JustifyBlock,BidiLtr,BidiRtl,Language,Anchor,Flash,Table,Smiley,PageBreak,Iframe,Save,NewPage,Preview,Print,Templates,ShowBlocks,Cut,Copy,Paste,PasteText,PasteFromWord,Undo,Redo,Find,Replace,SelectAll,Scayt,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,Styles,Format,Font,FontSize,TextColor,BGColor";
};
