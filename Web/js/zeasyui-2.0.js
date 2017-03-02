$(function () {
    $.fn.serializeJson = function () {
        var serializeObj = {};
        $(this.serializeArray()).each(function () {
            //if (this.value != "") {
            serializeObj[this.name] = this.value;
            //}
        });
        return serializeObj;
    };
});

function onError() {
    $.messager.alert("错误", "服务器错误", "error");
}

function Dlg(element) {
    this.element = element || $("#dlg");
    this.mainForm = this.element.find(".mainForm");
    this.modal = true;

    var me = this;

    var submitBtn = this.mainForm.find("[type='submit']");
    if (submitBtn.length == 0) {
        //手动注入一个
        this.mainForm.append("<input type='submit' style='display: none;'>");
    }

    this.mainForm.submit(function () {
        return false;
    })
    this.mainForm.submit(function (e) {
        $(this).find(".easyui-textbox").each(function (index) {
            $(this).next().children(".textbox-value").val($(this).next().children(".textbox-text").val());
        });
        me.submit();
        return false;
    });


    //样式
    this.element[0].style.padding = "20px";
    this.element[0].style.paddingRight = "50px";

    var me = this;
    this.buttons = [
        {
            text: "确认",
            iconCls: "icon-save",
            handler: function () {
                me.submit();
            }
        },
        {
            text: "关闭",
            iconCls: "icon-cancel",
            handler: function () {
                me.close();
            }
        }
    ];

}
!function (Dlg) {
    var arr = ["url", "action", "title", "iconCls", "modal", "width", "height", "resizable"];
    arr.forEach(function (ar) {
        Dlg.prototype[ar] = undefined;
    });

    function show() {
        var arr = ['title', 'top', 'left', 'width', 'height', 'modal', 'resizable', 'buttons', 'iconCls']
        var ps = {};
        for (var i = 0; i < arr.length; i++) {
            ps[arr[i]] = this[arr[i]];
        }
        this.element.dialog(ps);
    }
    function resetForm() {
        this.mainForm.form("reset");
    }
    function loadForm(params) {
        this.mainForm.form("load", params);
    }
    function close() {
        this.element.dialog("close");
    }
    function getFormJson() {
        return this.mainForm.serializeJson();
    }
    function getSubmitData() {
        var fj = this.getFormJson();
        fj.action = this.action;
        return fj;
    }
    function validForm() {
        var isValid = this.mainForm.form('validate');
        if (!isValid) {
            $.messager.alert("提示", "请正确填写每一项", "info");
            return false;
        }
        return true;
    }

    function submit() {
        var me = this;

        if (this.validForm() == false) {
            return false;
        }

        var submitData = this.getSubmitData();
        $.messager.progress();
        $.post(this.url, submitData, function (result) {
            if (!result.success) {
                $.messager.alert("失败", result.msg, "info");
                return;
            }
            $.messager.show({
                title: "成功",
                msg: "操作成功"
            });
            me.close();
            if (me.submitCallback) {
                me.submitCallback.call(me);
            }
        }, "json").complete(function () {
            $.messager.progress("close");
        }).error(onError);

    }
    Dlg.prototype = {
        show: show,
        resetForm: resetForm,
        loadForm: loadForm,
        close: close,
        getFormJson: getFormJson,
        getSubmitData: getSubmitData,
        submit: submit,
        validForm: validForm
    };
}(Dlg);


function Dg(element) {
    this.element = element || $("#dg");
    this.title_showAdd = "添加";
    this.title_showModify = "修改";
    this.iconCls_showAdd = "icon-add";
    this.iconCls_showModify = "icon-edit";
    this.action = "queryPage";
    this.fit = true;
    this.fitColumns = true;
    this.pagination = true;
    this.ctrlSelect = true;//ctrl多选
    this.singleSelect = false;//是否单选
    this.striped = true;//斑马条
    this.border = false;
    this.pageSize = 20;
    var me = this;
    this.onLoadError = function () {
        $.messager.alert("错误", "载入列表出错,请刷新页面后重试", "error");
    },
    this.loadFilter = function (data) {
        if (data.success === false) {
            $.messager.alert("载入列表出错", data.msg, "error");
            return {tota1:0,rows:[]}
        }
        if (me.zloadFilterSuccess) {
            me.zloadFilterSuccess(data);
        }
        if (data.rows) {
            return data;
        } else {
            return {
                total:  data.length,
                rows: data
            }
        }
    };
    this.onDblClickRow = function (rowIndex, rowData) {//双击表格事件,默认为调用修改方法
        me.element.datagrid("uncheckAll").datagrid("checkRow", rowIndex);
        me.showModify.call(me);
    }
    //  this.nowrap = true;//如果设置为true,将在同一行显示数据,有利于性能,默认为true
    this.columns = [[{ field: "id", title: "ID", hidden: false, checkbox: true },
        { field: 'username', title: '用户名', width: 100 },
        { field: 'password', title: '密码', width: 100 }
    ]];
    //初始化方法
    this.toolbar = this.element.find(".toolbar");
    this.searchForm = this.element.find(".searchForm");
    this.toolbar.find(".btn_add").click(function () {
        me.showAdd();
    });
    this.toolbar.find(".btn_modify").click(function () {
        me.showModify();
    });


    this.toolbar.find(".btn_del").click(function () {
        me.showDel();
    });
    this.toolbar.find(".btn_reload").click(function () {
        location.reload();
    });


    var submitBtn = this.searchForm.find("[type='submit']");
    if (submitBtn.length == 0) {
        //手动注入一个
        this.searchForm.append("<input type='submit' style='display: none;'>");
    }

    this.searchForm.submit(function () {
        return false;
    });
    this.searchForm.submit(function () {
        $(this).find(".easyui-textbox").each(function (index) {
            $(this).next().children(".textbox-value").val($(this).next().children(".textbox-text").val());
        });
        me.query();
    });
    this.searchForm.find(".btn_query").click(function () {
        me.query();
    });


}
!function (Dg) {
    var arr = ["url"];
    arr.forEach(function (ar) {

        Dg.prototype[ar] = undefined;
    });
    function init() {
        var me = this;
        var arr = ['url', 'onLoadError', 'loadFilter', 'fit', 'fitColumns', 'rownumbers', 'toolbar', 'pageSize', 'pagination', 'ctrlSelect',
            'singleSelect', 'onClickRow', 'onUnselect', 'onBeforeLoad', 'striped', 'border', 'nowrap', 'onDblClickRow',
            'columns', 'view', 'detailFormatter', 'onExpandRow', 'data'
        ];
        var ps = {};
        for (var i = 0; i < arr.length; i++) {
            ps[arr[i]] = this[arr[i]];
        }
        ps.queryParams = this.getQueryParams();
        console.log(ps);
        this.element.datagrid(ps);
    };
    function getFormJson() {
        return this.searchForm.serializeJson();
    }
    function getQueryParams() {
        var fj = this.getFormJson();
        fj.action = this.action;
        return fj;
    }

    function showAdd() {
        this.dlg.title = this.title_showAdd;
        this.dlg.iconCls = this.iconCls_showAdd;
        this.dlg.action = "add";
        this.dlg.resetForm();
        this.dlg.show();
        var me = this;
        this.dlg.submitCallback = function () {
            me.query();
        }
    }
    function showModify() {
        var record = this.getRecordByShowModify();
        if (!record) {
            return;
        }
        this.dlg.resetForm();
        this.dlg.loadForm(record);

        this.dlg.title = this.title_showModify;
        this.dlg.iconCls = this.iconCls_showModify;
        this.dlg.action = "modify";
        this.dlg.show();
        var me = this;
        this.dlg.submitCallback = function () {
            me.query();
        }
    }
    function getRecordByShowModify() {
        var records = this.getSelections();
        if (records.length == 0) {
            $.messager.alert("提示", "请选择需要操作的数据", "info");
            return false;
        }
        if (records.length > 1) {
            $.messager.alert("提示", "只能选择一条数据", "info");
            return false;
        }
        return records[0];

    }

    function getSelections() {
        return this.element.datagrid("getSelections");
    }

    function showDel() {
        var records = this.getSelections();
        if (records.length == 0) {
            $.messager.alert("提示", "请选择需要删除的数据", "info");
            return;
        }
        var me = this;
        var msg = "确认要将这<strong style=color:red>" + records.length + "</strong>条数据删除吗?";
        $.messager.confirm("确认删除", msg, function (r) {
            if (r) {
                var ids = "";
                for (var i = 0; i < records.length; i++) {
                    var record = records[i];
                    if (ids != "") {
                        ids += ",";
                    }
                    ids += record.id;
                }
                var postParams = {
                    ids: ids,
                    action: "del"
                };
                $.messager.progress();
                $.post(me.url, postParams, function (result) {
                    if (result.success) {
                        $.messager.show({
                            title: "成功",
                            msg: "删除成功"
                        });
                    } else {
                        $.messager.alert("错误", result.msg, "error");
                    }
                    me.element.datagrid("reload");
                }, "json").complete(function () {
                    $.messager.progress("close");
                }).error(onError);
            }
        });

    }


    function query() {
        this.element.datagrid("load", this.getQueryParams());
    }

    Dg.prototype = {
        init: init,
        getFormJson: getFormJson,
        getQueryParams: getQueryParams,
        getSelections: getSelections,
        getRecordByShowModify: getRecordByShowModify,
        showAdd: showAdd,
        showModify: showModify,
        showDel: showDel,
        query: query
    };

}(Dg);


