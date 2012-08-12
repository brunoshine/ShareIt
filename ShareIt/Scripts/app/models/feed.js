var Feed = Backbone.Model.extend({
    defaults: { Name: "" },
    urlRoot: '/api/feeds'
});
/*
var FeedCollection = Backbone.Collection.extend({
    model: Feed,
    url: "/api/feeds"
});
*/