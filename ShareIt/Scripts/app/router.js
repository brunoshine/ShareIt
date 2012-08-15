var AppRouter = Backbone.Router.extend({

    routes: {
        "": "intro",
        "create": "newFeed",
        "feed/:id": "feedDetails"
    },

    initialize: function () {
        window.views = {};
        window.views.intro = new introView({ htmlTemplate: window.templates.intro }).render();
        window.views.create = new createView().render();
        $("#main").html(window.views.intro)
        /*
        window.feeds = new FeedCollection;
        feeds.fetch({
            success: function (col, resp) {
            }
        });
        */
    },

    intro: function () {
        $("#main div:first").show();
    },
    newFeed: function () {
        $('#myModal').modal("show");
    },

    feedDetails: function (id) {
        var self = this;
        if (!window.activeModel) {
            $.blockUI();
            var feed = new Feed({ id: id });
            feed.fetch({
                success: function (model) {
                    if (model.attributes.Name != "") {
                        window.activeModel = model;
                        self.feedDetails(model.Id);
                    } else {
                        alert("No feed found!");
                        $.unblockUI();
                    }
                }
            });
        }else{
            $("#main").html(new detailsView({ model: window.activeModel }).render());
            $.unblockUI();
        }
    }
});