import axios from "axios";
import { get } from "core-js/core/dict";

const api = 'https://localhost:7097/api/khoaHoc'

const getAll = async (params: any) => {
  const res = await axios({
    method: 'get',
    url: `${api}/getall`,
    params: params
  })
  return res
}

const post = async (data: any) => {
  const res = await axios({
    method: 'post',
    url: `${api}`,
    data: data
  })

  return res
}

const khoaHoc = {post, getAll}
export default khoaHoc
