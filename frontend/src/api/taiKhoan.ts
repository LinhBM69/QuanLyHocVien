import axios from "axios";

const api = 'https://localhost:7097/api/taikhoan'

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

const taikhoan = { getAll, get }
export default taikhoan
