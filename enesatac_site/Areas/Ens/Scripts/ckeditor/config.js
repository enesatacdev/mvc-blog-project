/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	config.language = 'tr';
	config.uiColor = '#6a4671';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    filebrowserBrowseUrl: '/Areas/Ens/Scripts/ckfinder/ckfinder.html';
    filebrowserImageBrowseUrl: '/Areas/Ens/Scripts/ckfinder/ckfinder.html?type=Images';
    filebrowserFlashBrowseUrl: '/Areas/Ens/Scripts/ckfinder/ckfinder.html?type=Flash';
    filebrowserUploadUrl: '/Areas/Ens/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    filebrowserImageUploadUrl: '/Areas/Ens/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    filebrowserFlashUploadUrl: '/Areas/Ens/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.filebrowserImageUploadUrl = '/Areas/Ens/Scripts/Data';

    CKFinder.setupCKEditor(null, '/Areas/Ens/Scripts/ckfinder/');
};
