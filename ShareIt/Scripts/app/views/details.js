var detailsView = Backbone.View.extend({

    initialize: function(){
        this.template = _.template(window.templates.feedDetails);
    },

    template: null,

    render: function () {
        var html = this.template(this.model.toJSON());
        return $(this.el).append(html);
    }
});

var detailsListView = Backbone.View.extend({

    initialize: function () {
        this.template = _.template(window.templates.feedDetailsUrlList);
    },

    template: null,

    render: function () {
        var html = this.template(this.model.toJSON());
        return $(this.el).append(html);
    }


});