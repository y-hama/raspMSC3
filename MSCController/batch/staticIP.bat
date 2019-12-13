@echo off
netsh interface ipv4 set address name="イーサネット" source=static address=192.168.32.200 mask=255.255.255.0 gateway=""