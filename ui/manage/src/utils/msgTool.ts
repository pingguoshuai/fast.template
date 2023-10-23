import { ElMessageBox, MessageBoxData } from "element-plus";

export class msgTool {
    static async confirm(msg: string): Promise<MessageBoxData> {
        return ElMessageBox.confirm(msg, {
            confirmButtonText: '确定',
            cancelButtonText: '取消'
        });
    }
}