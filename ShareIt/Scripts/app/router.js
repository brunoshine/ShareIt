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
            var solaris = new Feed({ id: id });
            solaris.fetch({
                success: function (model) {
                    window.activeModel = model;
                    self.feedDetails(model.Id);
                }
            });
        }else{
            $("#main").html(new detailsView({model:window.activeModel}).render());
        }
    }
});