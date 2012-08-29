String.prototype.endsWith = function (suffix) {
    return this.indexOf(suffix, this.length - suffix.length) !== -1;
};

require([
    // templates
    "scripts/text!tpl/intro.html",
    "scripts/text!tpl/newFeed.html",
    "scripts/text!tpl/feedDetails.html",
    "scripts/text!tpl/item.html",

    // models
    "scripts/app/models/feed.js",

    // views
    "scripts/app/views/create.js",
    "scripts/app/views/details.js",
    "scripts/app/views/home.js",

    // routes
    "scripts/app/router.js",

    "scripts/json2.js"
    ],
    function (intro, newFeed, feedDetails, feedItem) {
        window.templates = {};
        window.templates.intro = intro;
        window.templates.newFeed = newFeed;
        window.templates.feedDetails = feedDetails;
        window.templates.feedItem = feedItem;

        window.app = new AppRouter();
        Backbone.history.start();
    }
);
