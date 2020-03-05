function AjaxTabController(ajaxSettings) {
    this.ajaxSettings = ajaxSettings;
    var self = "";
    this.initialise = function () {
        this.addEventListeners();
        self = this;
    }

    this.addEventListeners = function () {
        var tabs = document.getElementsByClassName(this.ajaxSettings.ajaxTabClassName);

        for (let tab of tabs) {
            tab.addEventListener("click", this.loadData);
        }
    }

    this.loadData = function (sender) {
        var id = sender.target.id;
        var url = window.location.href;

        var target = sender.target.getAttribute("aria-controls");
        console.log(self.ajaxSettings.urlsToParse);
        for (const currentUrl of self.ajaxSettings.urlsToParse) {
            if (target.indexOf(currentUrl.partialName) > -1) {
                url = currentUrl.url;
            }
        }

        if (url != window.location.href) {
            $.get(url, function (data) {
                $("#" + target).html(data);
            });
        }
    }
}