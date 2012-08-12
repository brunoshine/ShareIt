var createView = Backbone.View.extend({
    path: "#/feed/",
    events: {
        "click #createBtn": "onCreate"
    },
    initialize: function () {
        _.bindAll(this, 'render');
    },
    onCreate: function () {
        var _self = this;
        var model = new Feed({Name : $("#txtFeedName").val()});
        $('#myModal').modal("hide");

        model.save(null,{
            success: function (result) {
                window.location = _self.path + result.id;
                window.activeModel = result;
            }, error: function () { }, wait: true
        });
        /*
        window.feeds.create(model, {success :function(result){
            window.location = _self.path + result.id;
            window.activeModel = result;
        }, error: function () { }, wait:true});
        */
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