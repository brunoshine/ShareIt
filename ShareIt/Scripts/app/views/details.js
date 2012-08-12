var detailsView = Backbone.View.extend({
    show: function () {
        $("#main div:first").hide();
        $(this.el).show();
    },

    initialize: function(){
        this.template = _.template(window.templates.feedDetails);
    },

    template: null,

    render: function () {
        var html = this.template(this.model.toJSON());
        return $(this.el).append(html);
    }
});