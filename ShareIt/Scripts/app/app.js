String.prototype.endsWith = function (suffix) {
    return this.indexOf(suffix, this.length - suffix.length) !== -1;
};

//views
var introView = Backbone.View.extend({
    tagName: "div",
    events:{
        "click #newFeed": "onNewFeed"
    },
    initialize: function () {
        _.bindAll(this, 'render');
    },
    onNewFeed: function () {
        window.location = "#/create";
    },
    render: function () {
        return $(this.el).html(this.options.htmlTemplate);
    }
});

var createView = Backbone.View.extend({
    path:"#/feed/asd",
    events: {
        "click #createBtn": "onCreate"
    },
    initialize: function () {
        _.bindAll(this, 'render');
    },
    onCreate: function () {
        window.location = this.path;
        $('#myModal').modal("hide");
        return false;
    },
    render: function () {
        $(this.el).append(window.templates.newFeed);
        $("body").append(this.el);
        var me = this;
        $('#myModal').modal({ show: false }).on('hidden', function (e) {
            if (!window.location.href.endsWith(me.path)) {
                window.location = "#";
            }

        })
    }
});

var detailsView = Backbone.View.extend({
    show: function () {
        $("#main div:first").hide();
        $(this.el).show();
    },
    render: function () {
        return $(this.el).append(window.templates.feedDetails).hide();
    }
});

// Router
var AppRouter = Backbone.Router.extend({
    
    routes: {
        "" : "intro",
        "create": "newFeed", 
        "feed/:id": "feedDetails"
    },

    initialize: function () {
        window.views = {};
        window.views.intro = new introView({ htmlTemplate: window.templates.intro }).render();
        window.views.create = new createView().render();
        window.views.details = new detailsView().render();
        $("#main").html(window.views.intro).append(window.views.details);
    },

    intro: function(){
        $("#main div:first").show();
    },
    newFeed: function () {
        $('#myModal').modal("show");
    },
    
    feedDetails: function (id) {
        window.views.intro.hide();
        window.views.details.show();
    }
});


require([
    "scripts/text!tpl/intro.html",
    "scripts/text!tpl/newFeed.html",
    "scripts/text!tpl/feedDetails.html"],
    function (intro, newFeed, feedDetails) {
        window.templates = {};
        window.templates.intro = intro;
        window.templates.newFeed = newFeed;
        window.templates.feedDetails = feedDetails;

        window.app = new AppRouter();
        Backbone.history.start();

    }
);