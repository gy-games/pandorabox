<style scoped>
    .index {
        width: 100%;
        position: absolute;
        top: 0;
        bottom: 0;
        left: 0;
        text-align: center;
    }
    h1 {
        font-size: 20px;
    }
    h2{
        color: #AAA;
        font-size: 15px;
    }
    .index .ivu-row-flex {
        height: 100%;
    }
</style>
<template>
    <div class="index">
        <Row type="flex" justify="center" align="middle">
            <Col span="6" style="border: dashed;height: 200px; padding: 20px">
                <h1><a href="https://github.com/gy-games/pandorabox">Pandora Box</a></h1>
                <br/>
                <b>欢迎使用Pandora Box，本系统为光宇运维团队开发的一款基于非对称加密RSA的私密信息传递系统。数据由本地客户端进行加密、解密操作，密文通过网络进行传输，确保信息的安全性！</b>
                <br/><br/>
                <a type="success" href="software/PandoraBox.exe">下载最新客户端</a>
            </Col>
        </Row>

    </div>
</template>
<script>
    export default {
        data () {
            return {
            }
        },
        methods: {
        },
        mounted(){
        }
    };
</script>