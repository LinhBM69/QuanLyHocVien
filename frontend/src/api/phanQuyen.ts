import axios from "axios";

const api = 'https://localhost:7097/api/phanquyen'

const getAll = async (params: any) => {
  const res = await axios({
    method: 'get',
    url: `${api}/getall`,
    params: params
  })
  return res.data
}

const get = async (params: any) => {
  const res = await axios({
    method: 'get',
    url: `${api}`,
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

const put = async (data: any) => {
  const res = await axios({
    method: 'put',
    url: `${api}`,
    data: data
  })

  return res
}

const taikhoan = { getAll, get, post, put }
export default taikhoan
