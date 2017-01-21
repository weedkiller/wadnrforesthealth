﻿function modalDialogLink(anchorTag, javascriptReadyFunction, postData) {
    var element = jQuery(anchorTag);
    var randomNumber = Math.floor(Math.random() * 10000000);
    var dialogDivId = "SitkajQueryModalDialogUniqueID" + randomNumber;
    var dialogContentDivId = "SitkajQueryModalDialogContentUniqueID" + randomNumber;
    
    var postDataAsJson;
    if (typeof (postData) == "function") {
        postDataAsJson = postData();
    }
    else {
        postDataAsJson = postData;
    }
    // Load the form into the dialog div
    var config = { type: "GET", url: anchorTag.href };
    if (postDataAsJson != null) {
        config = { type: "POST", url: anchorTag.href, data: JSON.stringify(postDataAsJson), contentType: "application/json" };
    }
    SitkaAjax.ajax(config, function (htmlContentsOfDialogBox) {
        // defer loading of the contents so that the dialog is in place first by passing along the html string
        createBootstrapDialogForm(element, dialogDivId, dialogContentDivId, javascriptReadyFunction, htmlContentsOfDialogBox);
    });
    return false;
}
function findBootstrapDialogForm(optionalDialogFormId, dialogDiv)
{
    var form;
    if (!Sitka.Methods.isUndefinedNullOrEmpty(optionalDialogFormId)) {
        form = jQuery("#" + optionalDialogFormId, dialogDiv);
    }

    if (Sitka.Methods.isUndefinedNullOrEmpty(form)) {
        form = jQuery("form", dialogDiv);
    }

    if (form.length > 1) {
        throw new Error("Found more than 1 form to post!  Cannot proceed.");
    }

    return form;
}

function createBootstrapDialogForm(element, dialogDivId, dialogContentDivId, javascriptReadyFunction, htmlContentsOfDialogBox)
{
    // Retrieve values from the HTML5 data attributes of the link        
    var dialogTitle = element.attr("data-dialog-title");
    // Generate a unique id for the dialog div
    var loadingDivId = dialogDivId + "LoadingDiv";

    var screenWidth = jQuery(window).width();

    var width = parseInt(element.attr("data-dialog-width"));
    if (screenWidth <= 800)
    {
        width = 0;
    }
    
    if (width == 0) { width = "auto"; }
    else { width = width + "px"; }

    var saveButtonId = element.attr("data-save-button-id");
    var saveButtonText = element.attr("data-save-button-text");
    var cancelButtonId = element.attr("data-cancel-button-id");
    var cancelButtonText = element.attr("data-cancel-button-text");
    var optionalDialogFormId = element.attr("data-optional-dialog-form-id");
    var buttonCssClasses = element.attr("data-button-css-classes");

    var dialogDiv = jQuery(getModalDialogFromHtmlTemplate(dialogDivId, dialogTitle, htmlContentsOfDialogBox, width, saveButtonText, saveButtonId, cancelButtonText, cancelButtonId, buttonCssClasses, loadingDivId));
    dialogDiv.modal({ backdrop: "static" });
    dialogDiv.draggable({ handle: ".modal-header" });

    var saveButton = jQuery("#" + saveButtonId); 
    saveButton.click(function () {
        // Manually submit the form
        var form = findBootstrapDialogForm(optionalDialogFormId, dialogDiv);
        // Do not submit if the form
        // does not pass client side validation
        if (!form.valid()) {
            return false;
        }
        form.submit();
        return true;
    });

    dialogDiv.on("hide.bs.modal", function()
    {
        // Remove all qTip tooltips
        jQuery("*", dialogDiv).qtip("hide");
    });

    dialogDiv.on("hidden.bs.modal", function()
    {
        // It turns out that closing a bootstrap UI dialog
        // does not actually remove the element from the
        // page but just hides it. For the server side 
        // validation tooltips to show up you need to
        // remove the original form the page
        jQuery("#" + dialogDivId).remove();
    });

    // Setup the ajax submit logic, has to be done after the contents are loaded
    wireUpModalDialogForm(dialogDiv, loadingDivId, javascriptReadyFunction, optionalDialogFormId);
}

function wireUpModalDialogForm(dialogDiv, loadingDivId, javascriptReadyFunction, optionalDialogFormId) {
    // Enable client side validation
    jQuery.validator.unobtrusive.parse(dialogDiv);
    convertJQueryValidationErrorsToQtip();

    if (!Sitka.Methods.isUndefinedNullOrEmpty(javascriptReadyFunction)) {
        javascriptReadyFunction();
    }

    jQuery(".sitkaDatePicker").datepicker();

    // Instead of the typical SitkaAjax we use jquery.form.js here because it handles all types of ajax form posting, including file uploads. (SitkaAjax does not handle file uploads).
    // Not using SitkaAjax is OK here because we call SitkaAjax for login redirect and error handling.
    var form = findBootstrapDialogForm(optionalDialogFormId, dialogDiv);
    form.ajaxForm({
        url: this.action,
        type: this.method,
        beforeSubmit: function ()
        {
            jQuery(".progress-bar").html("Saving");
            jQuery(".progress").show();
        },
        success: function (result, textStatus, jqXhr) {
            // Piggy back off the centralized login required detection in Ajax handling in SitkaAjax
            SitkaAjax.handleLoginRedirect(result, textStatus, jqXhr, function () {
                jQuery(".progress").hide();
                // Check whether the post was successful
                if (!Sitka.Methods.isUndefinedNullOrEmpty(result) &&
                    !Sitka.Methods.isUndefinedNullOrEmpty(result.Success) &&
                    result.Success) {
                    // Close the dialog 
                    dialogDiv.modal("hide");
                    // Reload the updated data in the target div
                    if (!Sitka.Methods.isUndefinedNullOrEmpty(result.RedirectUrl)) {
                        window.location.href = result.RedirectUrl;
                    }
                    else {
                        // if none provided, just reload the current page
                        window.location.reload();
                    }
                }
                else
                {
                    // Reload the dialog to show model errors
                    dialogDiv.find('.modal-body').html(result);

                    // Setup the ajax submit logic
                    wireUpModalDialogForm(dialogDiv, loadingDivId, javascriptReadyFunction, optionalDialogFormId);
                }
            });
        },
        error: function (xhr, statusText)
        {
            jQuery(".progress").hide();
            dialogDiv.modal("hide");
            // Piggy back off the centralized error Ajax handling in SitkaAjax
            SitkaAjax.errorHandler(xhr, statusText);
        }
    });
}

function getModalDialogFromHtmlTemplate(dialogDivId, dialogTitle, dialogContent, width, saveButtonText, saveButtonId, closeButtonText, closeButtonId, buttonCssClasses, loadingDivId)
{
    var modalDialogHtml =
    "<div class='modal firma-modal' id='" + dialogDivId + "' tabindex='-1'>" +
        "<div class='modal-dialog firma-modal-dialog' style = 'width: " + width + "'>" +
            "<div class='modal-content'>" +
                "<div class='modal-header'>" +
                    "<button type='button' class='modal-close-button btn " + buttonCssClasses + "' data-dismiss='modal'><span>&times;</span></button>" +
                    "<span class='modal-title'>" + dialogTitle + "</span>" +
                "</div>" +
                "<div class='modal-body'>" + dialogContent + "</div>" +
                "<div class='modal-footer'>" +
                    "<span><sup><span class=\"glyphicon glyphicon-flash\" style=\"color: #800020; font-size: 8px; \"></span></sup> Required Field</span>" +
                    "<div class='modal-footer-buttons'>" +
                        "<button type='button' id='" + saveButtonId + "' class='btn " + buttonCssClasses + "'>" + saveButtonText + "</button>" +
                        "<button type='button' id='" + closeButtonId + "' class='btn " + buttonCssClasses + "' data-dismiss='modal'>" + closeButtonText + "</button>" +
                    "</div>" +
                "</div>" +
                "<div class='progress' style='display:none'>" +
                    "<div class='progress-bar progress-bar-info progress-bar-striped active' role='progressbar' style='width:100%'>Saving</div>" +
                "</div>" +
            "</div>" +
        "</div>" +
    "</div>";

    return modalDialogHtml;
}
