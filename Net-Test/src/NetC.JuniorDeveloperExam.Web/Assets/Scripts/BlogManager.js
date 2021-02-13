var BlogManager = function BlogManager() {
    var self = this;

    BlogManager.prototype.OnSaveCommentSuccessfully = function (data) {
        self.ResetFormData();
        if (data && data.IsAdded == true) {
           self.FillNewComment("#commentsSection", data.Comment);
        }
    }
    BlogManager.prototype.OnSaveReplySuccessfully = function (data) {
        if (data && data.IsAdded == true) {
            var replyComment = data.Reply;
            var commentId = data.Reply.CommentID;
            FillNewComment("#comments_" + commentId + "_replied", replyComment);
            self.ResetReplyForm(commentId);
        }
    }
    BlogManager.prototype.FillNewComment = function (id, comment) {
        debugger;
        var html = "";
        var name = "";
        comment.Name.split(" ").splice(0, 2).map(function (item) {
            name += item[0];
        });
        html += " <div class='media mb-4'>";
        html += "<div class='d-flex mr-3 rounded-circle user-avatar'><label>" + name + "</label></div>";
        html += "<div class='media-body'>";
        html += "<h5 class='mt-0'>" + comment.Name + "<small><em>( " + comment.Date + " )</em></small></h5>";
        html += comment.Message;
        html += "<div></div>";
        $(id).append(html);
    }
    BlogManager.prototype.ResetReplyForm = function (commentId) {
        $("#collapseReply_" + commentId + " #Reply_Name").val("");
        $("#collapseReply_" + commentId + " #Reply_Name").removeClass("is-valid");
        $("#collapseReply_" + commentId + " #Reply_Email").val("");
        $("#collapseReply_" + commentId + " #Reply_Email").removeClass("is-valid");
        $("#collapseReply_" + commentId + " #Reply_Message").val("");
        $("#collapseReply_" + commentId + " #Reply_Message").removeClass("is-valid");
    }
    BlogManager.prototype.ResetFormData = function () {
        $("#Comment_Name").val("");
        $("#Comment_Name").removeClass("is-valid");
        $("#Comment_Email").val("");
        $("#Comment_Email").removeClass("is-valid");
        $("#Comment_Message").val("");
        $("#Comment_Message").removeClass("is-valid");
    }
}