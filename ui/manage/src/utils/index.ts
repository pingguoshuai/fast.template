
import dateFormat from 'dateformat'

/**
 * 
 * @param date 时间格式化
 * @param mask 
 * @returns 
 */
export function formatDate(date: Date, mask: string = 'yyyy-mm-dd') {
    return date && dateFormat(date, mask)
}