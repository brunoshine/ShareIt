var introView = Backbone.View.extend({
    tagName: "div",
    events: {
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